using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Victory : MonoBehaviour
{
    public void nextLevelButton()
    {
        string difficulty = PlayerPrefs.GetString("Difficulty");

        if (difficulty == "Easy")
        {
            SceneManager.LoadScene("Medium");
        }

        if (difficulty == "Medium")
        {
            SceneManager.LoadScene("Hard");
        }
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
