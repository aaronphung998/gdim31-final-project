using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //This method is called when the object enters a collider trigger. 
        //We don't want an infinite number of pillars in the game world 
        //Here we should see if the pillar has entered the "Despawn" trigger so that we can destroy the object.
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }


    }
}
