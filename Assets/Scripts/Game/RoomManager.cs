using UnityEngine.SceneManagement;
using UnityEngine;

public class RoomManager
{
    public int LoadNextLevel(int level, bool win = false)
    {
        int index = 0;
        if (win)
        {
            index = SceneManager.GetSceneByName("WinScreen").buildIndex;
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            index = SceneManager.GetSceneByName("Room_" + level).buildIndex;
            SceneManager.LoadScene("Room_" + level);
        }
        return index;
    }

    public int LoadNextBoss()
    {
        int index = 0;
        index = SceneManager.GetSceneByName("Boss_1").buildIndex;
        SceneManager.LoadScene("Boss_1");
        return index;
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
