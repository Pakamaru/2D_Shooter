using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager
{
    public void LoadNextLevel(int level, bool win = false)
    {
        if (win)
            SceneManager.LoadSceneAsync("WinScreen");
        else
            SceneManager.LoadSceneAsync("Room_" + level);
    }

    public void OnPlayerEscapeButton()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
            SceneManager.LoadSceneAsync("MainMenu");
        else
            Application.Quit();
    }
}
