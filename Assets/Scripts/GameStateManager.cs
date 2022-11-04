using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void OnGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
