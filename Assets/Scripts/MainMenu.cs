using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        FindObjectOfType<GameController>().currentRoomLevel = 1;
        FindObjectOfType<GameController>().StartGame();
    }

    public void OnOptions()
    {

    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
