using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController Instance;
    private RoomManager roomManager;
    [SerializeField]
    public int currentRoomLevel;
    public Room currentRoom;
    public Player Player { get; set; }

    private int roomCount = 9;
    private GameObject pauseScreen;

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
        pauseScreen = GetComponentInChildren<Canvas>().gameObject;
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
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
            Player.Level = 1;
            Player.MaxXP = 0;
            Player.CurXP = 0;
            Player.SetVars(300, 20, 2f);
            Player.Weapon = Player.transform.Find("Body").Find("Gun").gameObject.GetComponent<Weapon>();
            Player.Weapon.SetVars(this.gameObject, 10, 1, 5);
            Player.GameStarted();
        }
    }

    public void PauseGame()
    {
        StopGameAndInput(true);
        pauseScreen.SetActive(true);
    }

    public void StopGameAndInput(bool stop)
    {
        if (stop)
        {
            Time.timeScale = 0;
            Player.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        }
        else
        {
            Time.timeScale = 1;
            Player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Level");
        }
    }
    
    public void QuitLevel()
    {
        StopGameAndInput(false);
        pauseScreen.SetActive(false);
        roomManager.GoToMainMenu();
    }

    public void ResumeLevel()
    {
        StopGameAndInput(false);
        pauseScreen.SetActive(false);
    }
}
