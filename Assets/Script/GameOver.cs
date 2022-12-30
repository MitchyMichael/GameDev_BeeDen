using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void tryAgainButton()
    {
        string difficulty = PlayerPrefs.GetString("Difficulty");

        if (difficulty == "Easy")
        {
            SceneManager.LoadScene("Easy");
        }

        if (difficulty == "Medium")
        {
            SceneManager.LoadScene("Medium");
        }

        if (difficulty == "Hard")
        {
            SceneManager.LoadScene("Hard");
        }
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
