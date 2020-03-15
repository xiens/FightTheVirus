using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Reads player input
public class PlayerInput : MonoBehaviour
{

    public float horizontalAxis = 0f;
    public float verticalAxis= 0f;             
    public bool isJumping = false;//to end adding jump force in playermovement
    public bool endJump = true; // to end coroutine


    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && endJump)
        {
            isJumping = true;
            endJump = false;
        }

    }


}
