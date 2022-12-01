using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Obstacle
{
    // Start is called before the first frame update
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }
    }
}
