using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float maxSpeed = 20.0f;
    [SerializeField]
    private float jumpForce = 7.0f;
    [SerializeField]
    private float maxJumpSpeed = 10.0f;

    Rigidbody2D rigidbody;
    PlayerInput playerInput;
    float startJumpPos;
    bool checkJumpLand = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        if(playerInput.horizontalAxis > 0)
        {
            if(rigidbody.velocity.x < maxSpeed)
            {
                rigidbody.AddForce(Vector3.right * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }
        if (playerInput.horizontalAxis < 0)
        {
            rigidbody.AddForce(Vector3.left * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if (playerInput.isJumping)
        {
            startJumpPos = transform.position.y;
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            playerInput.isJumping = false;
            StartCoroutine("endJump");
        }

        if (rigidbody.position.y < startJumpPos + 0.1f && checkJumpLand)
        {
            playerInput.endJump = true;
            checkJumpLand = false;
        }
    }

    IEnumerator endJump()
    {
        yield return new WaitForSeconds(0.5f);
        checkJumpLand = true;
    }
}
