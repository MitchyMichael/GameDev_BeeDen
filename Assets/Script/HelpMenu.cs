using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject helpMenu;

    public void Help()
    {
        helpMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Back()
    {
        helpMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
