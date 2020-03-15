using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO improve aiming (clamping angles, barrel speed)
//TODO spawn mini viruses toward player

//Shooting virus
public class BlueVirus : Virus
{
    [SerializeField] private GameObject barrel;
    [SerializeField] private float maxAngle = 60.0f;
    [SerializeField] private float barrelSpeed = 0.5f;

    private float currentAngle;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = 0;

        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine("moveBarrel");
    }


    IEnumerator moveBarrel()
    {
        while (true)
        {
            //calculate angle in straight line to player
            float destAngle = Vector2.Angle(transform.position, player.transform.position);

            float angle = destAngle * barrelSpeed * Time.fixedDeltaTime;

            RaycastHit2D hit = Physics2D.Raycast(barrel.transform.position, -barrel.transform.right, 100, LayerMask.GetMask("Player"));

            if (hit)
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    print("casting viruses toward player");
                }
            }
            else //TODO check if the angle is in desired range
            {
                barrel.transform.Rotate(Vector3.forward, angle);
            }


            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

}
