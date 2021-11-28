using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        FindObjectOfType<GameController>().currentRoomLevel = 1;
        FindObjectOfType<GameController>().NextLevel();
    }

    public void OnOptions()
    {

    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
