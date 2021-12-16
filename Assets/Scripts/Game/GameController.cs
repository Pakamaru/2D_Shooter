using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController Instance;
    private RoomManager roomManager;
    [SerializeField]
    private int roomCount = 9;
    public int currentRoomLevel;
    public Room currentRoom;
    public Player Player { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            roomManager = new RoomManager();
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {/*
        if (Input.GetKey(KeyCode.Escape))
        {
            roomManager.OnPlayerEscapeButton();
        }*/
    }

    public void GameStartEndless()
    {
        new EndlessGame(1);
    }

    public void StartGame()
    {
        int randomNumber = Random.Range(1, roomCount);
        roomManager.LoadNextLevel(randomNumber);
        if (SceneManager.GetActiveScene().buildIndex != randomNumber)
        {
            StartCoroutine("waitForSceneLoad", randomNumber);
        }
    }

    public void NextLevel()
    {
        int randomNumber = Random.Range(1, roomCount);
        roomManager.LoadNextLevel(randomNumber);
        if (SceneManager.GetActiveScene().buildIndex != randomNumber)
        {
            StartCoroutine("waitForSceneLoad", randomNumber);
        }
    }

    private IEnumerator waitForSceneLoad(int sceneNumber)
    {
        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            Player = GameObject.Find("Player").GetComponent<Player>();
            Player.SetVars(100, 10, 2f);
            Player.Weapon = Player.transform.Find("Body").Find("Gun").gameObject.GetComponent<Weapon>();
            Player.Weapon.SetVars(this.gameObject, 10, 1, 5);
            print(Player.CurSpeed);
        }
    }

}
