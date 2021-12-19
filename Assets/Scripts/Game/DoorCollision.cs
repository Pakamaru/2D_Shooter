using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    private Room room;
    private GameController gameController;

    private void Start()
    {
        room = GameObject.FindGameObjectWithTag("Room").GetComponent<Room>();
        gameController = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (room.GetEnemyCount() == 0)
            {
                gameController.SavePlayer(collision.gameObject.GetComponent<Player>());
                gameController.currentRoomLevel += 1;
                if (gameController.currentRoomLevel == 10)
                    gameController.WinGame();
                else
                    gameController.NextLevel();
            }
        }
    }
}
