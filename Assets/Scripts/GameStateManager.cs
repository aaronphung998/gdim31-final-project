using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void onGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
