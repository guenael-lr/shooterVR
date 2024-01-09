using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    //create private timer 
    private float timer = 0.0f;

    private float velocity;

    void Start()
    {
        //set velocity to y axis
        velocity = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //update timer 
        timer += Time.deltaTime;
        //update position z with velocity
        transform.position += transform.forward * velocity * Time.deltaTime;



        //if timer is greater than 5 seconds destroy bullet
        if (timer > 2.5f)
        {
            Destroy(gameObject);
        }

    }

    //check if colliding with another object
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
