using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;
    public static float ObstacleSpeed;

    [SerializeField]
    private int accelerationTime;   // how much time before speeding up the obstacles
    [SerializeField]
    private float startSpeed;       // start speed
    [SerializeField]
    private float speedIncrement;     // how much speed will increase each interval

    private static GameStateManager _instance;

    private int incrementTime;

    private static bool endGame;

    private static float endTime;

    void Start()
    {
        incrementTime = 0;
        if (_instance == null)
        {
            _instance = this;
            ObstacleSpeed = startSpeed;
            DontDestroyOnLoad(_instance);
            endGame = false;
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
        endGame = false;
        ObstacleSpeed = startSpeed;
        incrementTime = 0;
    }


    public static void GameOver()
    {
        endGame = true;
        endTime = 2 + Time.time;
        //SceneManager.LoadScene("GameOver");
        OnGameOver();
    }

    void Update()
    {
        if (Time.time >= incrementTime * accelerationTime)
        {
            incrementTime++;
            ObstacleSpeed += speedIncrement;
        }
        if (endGame && Time.time >= endTime)
        {
            SceneManager.LoadScene("GameOver");
            endGame = false;
        }
    }
}
