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
    [SerializeField] private float barrelSpeed = 25.0f;

    private float currentAngle;
    private GameObject player;
    private Quaternion lookRotation;
    private Vector3 direction;

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
            Vector2 playerDir = player.transform.position - transform.position;
            float destAngle = Vector2.Angle(barrel.transform.right, playerDir);
            float dotproduct =Vector2.Dot(barrel.transform.right, playerDir.normalized);
            //float destAngle = angle1 - angle2; /*= Vector2.Angle(transform.position);*/
            //print("barrel: " + transform.position.normalized);
            //print("player: " + player.transform.position.normalized);
            print(playerDir.normalized);
            float angle = barrelSpeed * Time.fixedDeltaTime;

            RaycastHit2D hit = Physics2D.Raycast(barrel.transform.position, -barrel.transform.right, 100, LayerMask.GetMask("Player"));
            Debug.DrawRay(barrel.transform.position, -barrel.transform.right*100, Color.black);
            Debug.DrawRay(barrel.transform.position, playerDir * 100, Color.yellow);


            if (hit)
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    print("casting viruses toward player");
                }
            }
            else //TODO check if the angle is in desired range
            {
                barrel.transform.right = playerDir;
                ////find the vector pointing from our position to the target
                //direction = (player.transform.position - transform.position).normalized;

                
                ////create the rotation we need to be in to look at the target
                //lookRotation = Quaternion.LookRotation(direction);

                //barrel.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
                ////rotate us over time according to speed until we are in the required rotation
                //barrel.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * barrelSpeed);

                //barrel.transform.Rotate(Vector3.forward, angle);


            }


            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

}
