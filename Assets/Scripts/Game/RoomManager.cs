using UnityEngine.SceneManagement;

public class RoomManager
{
    public void LoadNextLevel(int level, bool win = false)
    {
        if (win)
            SceneManager.LoadScene("WinScreen");
        else
            SceneManager.LoadScene("Room_" + level);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
