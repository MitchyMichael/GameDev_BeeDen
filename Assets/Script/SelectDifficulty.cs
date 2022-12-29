using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    public void easyButton()
    {
        SceneManager.LoadScene("Easy");
    }

    public void mediumButton()
    {
        SceneManager.LoadScene("Medium");
    }

    public void hardButton()
    {
        SceneManager.LoadScene("Hard");
    }
}
