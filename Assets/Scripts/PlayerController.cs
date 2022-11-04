using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float upForce;
    [SerializeField]
    private Text scoreDisplay;
    [SerializeField]
    private AudioSource deathSound;
    [SerializeField]
    private SpriteRenderer sprite;

    private int score;

    private bool alive;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        score = 0;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alive && isGrounded)
        {
            rb.velocity = transform.up * upForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GameOver")
        {
            alive = false;
            rb.angularVelocity = 5000;
            GameStateManager.OnGameOver();
        }
        else if (collision.gameObject.tag == "Score" && alive)
        {
            score += 1;
            scoreDisplay.text = score.ToString();
        }
        else if (collision.gameObject.tag == "GroundTrigger")
        {
            isGrounded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundTrigger")
        {
            isGrounded = false;
        }
    }
}
