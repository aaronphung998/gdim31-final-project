using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Obstacle
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
