using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameStateManager gsm;

    // Start is called before the first frame update

    public void StartGame()
    {
        gsm.StartGame();
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
