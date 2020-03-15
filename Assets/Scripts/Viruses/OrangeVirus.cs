using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This virus scales up and down
public class OrangeVirus : Virus
{
    [SerializeField]
    private float scalingFactor = 0.3f;
    [SerializeField]
    private float maxScale = 2.0f;


    private Vector3 minScale;
    private bool scaleUp = true;
    // Start is called before the first frame update
    void Start()
    {
        minScale = transform.localScale;
    }


    void FixedUpdate()
    {
        if(transform.localScale.x > minScale.x * maxScale)
        {
            scaleUp = false;
        }
        else if(transform.localScale.x < minScale.x)
        {
            scaleUp = true;
        }

        float scaleUpDown = scaleUp ? 1 : -1;

        transform.localScale += transform.localScale * scalingFactor * scaleUpDown * Time.fixedDeltaTime;

    }


}
