using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float speed;
    public bool isMoving;

    // Start is called before the first frame update
    public void Start()
    {
        speed = GameStateManager.ObstacleSpeed;
        GameStateManager.OnGameOver += StopMoving;
        isMoving = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isMoving)
        {
            speed = GameStateManager.ObstacleSpeed;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //This method is called when the object enters a collider trigger. 
        //We don't want an infinite number of pillars in the game world 
        //Here we should see if the pillar has entered the "Despawn" trigger so that we can destroy the object.
    }

    private void StopMoving()
    {
        isMoving = false;
    }

    public void OnDestroy()
    {
        GameStateManager.OnGameOver -= StopMoving;
    }
}
