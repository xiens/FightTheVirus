using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Virus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 20.0f);
    }
}
