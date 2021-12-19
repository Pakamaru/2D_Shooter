using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    private Enemy boss;
    private int enemyCount;

    private void Start()
    {
        GameObject tempEnemies = GameObject.FindGameObjectWithTag("Enemy");
        boss = tempEnemies.GetComponent<Enemy>();
        enemyCount = 1;
        boss.SetVars(2500, 100, 3);
        boss.Weapon.SetVars(33, 0.3f, 10);
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
