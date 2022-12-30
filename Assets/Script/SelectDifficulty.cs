using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    public void easyButton()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
        SceneManager.LoadScene("Easy");
    }

    public void mediumButton()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
        SceneManager.LoadScene("Medium");
    }

    public void hardButton()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
        SceneManager.LoadScene("Hard");
    }
}
