using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    protected List<Wave> waves = new List<Wave>();
    private Wave curWave;
    protected float delay;
    protected int waveCount;
    private List<Vector3> spawnPositions;

    protected void Init()
    {
        spawnPositions = GameObject.FindGameObjectsWithTag("EnemySpawnLocation").Select(o => o.transform.position).ToList();
        for (int i = 0; i < waveCount; i++)
        {
            waves.Add(new Wave(spawnPositions));
        }
        curWave = waves[0];
        StartWave();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void StartWave()
    {
        StartCoroutine(curWave.StartWave(delay));
    }
}
