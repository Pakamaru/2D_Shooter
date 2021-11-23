using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wave
{
    private GameObject prefab = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Enemy.prefab", typeof(GameObject));
    private List<GameObject> enemies = new List<GameObject>();
    private int enemyCount = 3;

    private List<Vector3> spawnPoints;

    public Wave(List<Vector3> spawnPoints)
    {
        this.spawnPoints = spawnPoints;
        //enemyCount = enemies.Count;
    }

    public IEnumerator StartWave(float delay)
    {
        int spawner = 0;
        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(MonoBehaviour.Instantiate(prefab, spawnPoints[spawner], new Quaternion()));
            enemies[i].GetComponent<Enemy>().SetVars(10, 1, 2f);
            spawner = (spawner < spawnPoints.Count) ? spawner++ : spawner = 0;
            yield return new WaitForSeconds(delay);
        }
    }
}
