using UnityEngine;
using System.Linq;

public class Room : MonoBehaviour
{
    private Enemy[] enemies;
    private int enemyCount;

    private void Start()
    {
        GameObject[] tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameController controller = FindObjectOfType<GameController>();
        enemies = tempEnemies.Select(x => x.GetComponent<Enemy>()).ToArray();
        enemyCount = tempEnemies.Length;
        controller.currentRoom = transform.GetComponent<Room>();
        float multi = controller.currentRoomLevel * 1.5f;
        foreach (Enemy enemy in enemies)
        {
            enemy.SetVars(Mathf.RoundToInt(50 * multi), Mathf.RoundToInt(10 * multi), 2f, 50 * multi);
        }
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
