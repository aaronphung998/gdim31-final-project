using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject spriteObject;
    [SerializeField]
    private float upForce;
    [SerializeField]
    private float flyForce;
    [SerializeField]
    private TMP_Text scoreDisplay;
    [SerializeField]
    private AudioSource deathSound;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite groundSprite;
    [SerializeField]
    private Sprite airSprite;
    [SerializeField]
    private float scoreIncrementTime;     // time between each time that the game increments the player's score
    [SerializeField]
    private int coinValue;
    [SerializeField]
    private float maxFlyingVelocity;
    [SerializeField]
    private AudioSource bgm;
    [SerializeField]
    private AudioSource coinSound;
    [SerializeField]
    public AudioSource portalSound;

    private int score;
    private float nextScore;

    private bool alive;

    private bool isGrounded;

    private bool isInvincible;
    private float timeAt;

    public static bool isFlying;

    private float xPosition;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        score = 0;
        timeAt = 0;
        isGrounded = false;
        isFlying = false;
        isInvincible = false;
        xPosition = transform.position.x;
        nextScore = Time.time + scoreIncrementTime;
        changeSprite(groundSprite);
    }

    private void Die()
    {
        if (alive)
        {
            bgm.Stop();
            deathSound.Play();
            alive = false;
            rb.angularVelocity = 5000;
            if (PlayerPrefs.GetInt("score") < score)
            {
                PlayerPrefs.SetInt("score", score);
            }
            GameStateManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alive && !isFlying && isGrounded)
        {
            rb.velocity = transform.up * upForce;
        }
        else if (Input.GetKey(KeyCode.Space) && alive && isFlying && !PauseScreen.GameIsPaused)
        {
            rb.velocity = transform.up * rb.velocity.y + transform.up * flyForce;
        }
        if (transform.position.x != xPosition && alive)
        {
            Vector3 pos = transform.position;
            pos.x = xPosition;
            transform.position = pos;
        }
        if (transform.rotation != Quaternion.identity && alive && !isFlying)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (isFlying && alive)
        {
            if (rb.velocity.y > maxFlyingVelocity)
            {
                rb.velocity = transform.up * maxFlyingVelocity;
            }
            else if (rb.velocity.y < -maxFlyingVelocity)
            {
                rb.velocity = transform.up * -maxFlyingVelocity;
            }
            transform.eulerAngles = Vector3.forward * Mathf.Atan(rb.velocity.y / 2 / (GameStateManager.ObstacleSpeed)) * 180 / Mathf.PI;
        }
        if (Time.time > nextScore && alive)
        {
            nextScore = Time.time + scoreIncrementTime;
            increaseScore(1);
        }
        if (isInvincible)
        {
            if (Time.time - timeAt > 4f)
            {
                spriteRenderer.color = Color.white;
                isInvincible = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GameOver" && !isInvincible)
        {
            Die();
        }
        else if (collision.gameObject.tag == "Invincible")
        {
            timeAt = Time.time;
            spriteRenderer.color = Color.yellow;
            isInvincible = true;
        }
        else if (collision.gameObject.tag == "Score" && alive)
        {
            coinSound.Play();
            increaseScore(coinValue);
        }
        else if (collision.gameObject.tag == "GroundTrigger")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "FlyPowerupTrigger")
        {
            isFlying = true;
            portalSound.Play();
            changeSprite(airSprite);
        }
        else if (collision.gameObject.tag == "FlyPowerdownTrigger")
        {
            isFlying = false;
            portalSound.Play();
            changeSprite(groundSprite);
        }

    }

    private void changeSprite(Sprite s)
    {
        spriteRenderer.sprite = s;
    }

    private void increaseScore(int value)
    {
        score += value;
        scoreDisplay.text = score.ToString();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundTrigger")
        {
            isGrounded = false;
        }
    }
}
