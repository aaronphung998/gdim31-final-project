using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _score;
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Highest Score: " + PlayerPrefs.GetInt("score");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
