using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;

public class RoomManager
{
    public void LoadNextLevel(int level)
    {
        if (level < 3)
            SceneManager.LoadScene("Room_" + level);
        else
            SceneManager.LoadScene("WinScreen");
    }

    public void OnPlayerEscapeButton()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
            SceneManager.LoadScene("MainMenu");
        else
            Application.Quit();

    }
}
