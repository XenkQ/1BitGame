using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Enemy enemyPrefab;

    [Header("Spawning Properites")]
    [SerializeField] private Transform[] spawningPoints;
    private int spawnAfter;
    private int spawnAtSecond;
    private int currentEnemy;

    [Header("Stage Properites")]
    [SerializeField] private int enemyNumberInStage;

    [Header("Other Scripts")]
    [SerializeField] private Timer timer;

    [Header("Spawned Enemies")]
    [SerializeField] private List<Enemy> enemies;

    private void Start()
    {
        PoolEnemies();
        currentEnemy = enemies.Count - 1;
        spawnAtSecond = timer.StartTime;
        spawnAfter = timer.StartTime / enemyNumberInStage;
    }

    private void PoolEnemies()
    {
        for (int i = 0; i < enemyNumberInStage; i++)
        {
            enemies.Add(Instantiate(enemyPrefab, RandomSpawnPoint(), Quaternion.identity, transform));
            enemies[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (CanSpawnEnemy())
        {
            EnableEnemy();
            spawnAtSecond -= spawnAfter;
        }
    }

    private bool CanSpawnEnemy()
    {
        return timer.time == spawnAtSecond;
    }

    private void EnableEnemy()
    {
        if (currentEnemy >= 0)
        {
            enemies[currentEnemy].gameObject.SetActive(true);
            currentEnemy--;
        }
    }

    private Vector2 RandomSpawnPoint()
    {
        return spawningPoints[Random.Range(0, spawningPoints.Length)].position;
    }
}
