using UnityEngine;

public class Room : MonoBehaviour
{
    private int enemyCount;

    private void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        FindObjectOfType<GameController>().currentRoom = transform.GetComponent<Room>();
    }

    public void KillOneEnemy()
    {
        enemyCount--;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
}
