using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController Instance;
    public int currentRoomLevel;
    public Room currentRoom;
    public Player player;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            new RoomManager().OnPlayerEscapeButton();
        }
    }

    public void GameStartEndless()
    {
        new EndlessGame(1);
    }

    public void NextLevel()
    {
        new RoomManager().LoadNextLevel(currentRoomLevel);
    }
}
