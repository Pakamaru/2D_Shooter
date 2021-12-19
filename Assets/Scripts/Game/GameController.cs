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
    public Weapon Weapon { get; set; }

    private int roomCount = 9;
    [SerializeField]
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
        pauseScreen.SetActive(false);
    }

    public void StartGame()
    {
        int randomNumber = Random.Range(1, roomCount);
        int index = roomManager.LoadNextLevel(randomNumber);
        if (SceneManager.GetActiveScene().buildIndex != randomNumber)
        {
            StartCoroutine("waitForFirstSceneLoad", randomNumber);
        }
    }

    public void NextLevel()
    {
        if (currentRoomLevel == 9)
        {
            NextBossLevel();
            return;
        }
        int randomNumber = Random.Range(1, roomCount);
        int index = roomManager.LoadNextLevel(randomNumber);
        if (SceneManager.GetActiveScene().buildIndex != randomNumber)
        {
            StartCoroutine("waitForSceneLoad", randomNumber);
        }
    }

    private void NextBossLevel()
    {
        int number = 10;
        roomManager.LoadNextBoss();
        if (SceneManager.GetActiveScene().buildIndex != number)
        {
            StartCoroutine("waitForSceneLoad", number);
        }
    }

    public void WinGame()
    {
        StopGameAndInput(true);
        roomManager.LoadNextLevel(1, true);
    }

    public void LoseGame()
    {
        StopGameAndInput(true);
        roomManager.LoadLoseScreen();
    }

    private IEnumerator waitForBossSceneLoad()
    {
        while (!SceneManager.GetSceneByName("Boss_1").isLoaded)
        {
            yield return null;
        }
        if (SceneManager.GetSceneByName("Boss_1").isLoaded)
        {
            GameObject.Find("Player").GetComponent<Player>().InitPlayer(Player, Weapon);
            GameObject.Find("Player").GetComponent<PlayerInputScript>().InitPlayer(Player);
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
            GameObject.Find("Player").GetComponent<Player>().InitPlayer(Player, Weapon);
            GameObject.Find("Player").GetComponent<PlayerInputScript>().InitPlayer(Player);
        }
    }

    private IEnumerator waitForFirstSceneLoad(int sceneNumber)
    {
        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            Player = GameObject.Find("Player").GetComponent<Player>();
            Player.Level = 1;
            Player.MaxXP = 100;
            Player.CurXP = 0;
            Player.SetVars(300, 20, 2f);
            Player.Weapon = Player.GetComponentInChildren<Weapon>();
            Player.Weapon.SetVars(10, 1, 3);
            Player.GameStarted();
        }
    }

    public void SavePlayer(Player player)
    {
        Player = new Player();
        Player.CurDmg = player.CurDmg;
        Player.CurHealth = player.CurHealth;
        Player.CurSpeed = player.CurSpeed;
        Player.CurXP = player.CurXP;
        Player.MaxDmg = player.MaxDmg;
        Player.MaxHealth = player.MaxHealth;
        Player.MaxSpeed = player.MaxSpeed;
        Player.MaxXP = player.MaxXP;
        Weapon = new Weapon();
        Weapon.SetVars(player.Weapon.MaxMagazine, player.Weapon.GetAS(), player.Weapon.GetRS());
        Weapon.curMagazine = player.Weapon.curMagazine;
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
            GameObject.Find("Player").GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        }
        else
        {
            Time.timeScale = 1;
            GameObject.Find("Player").GetComponent<PlayerInput>().SwitchCurrentActionMap("Level");
        }
    }

    public void QuitToMainMenu()
    {
        roomManager.GoToMainMenu();
    }
    
    public void QuitLevel()
    {
        StopGameAndInput(false);
        pauseScreen.SetActive(false);
        QuitToMainMenu();
    }

    public void ResumeLevel()
    {
        StopGameAndInput(false);
        pauseScreen.SetActive(false);
    }
}
