using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Enemy enemyPrefab;

    [Header("Spawning Properites")]
    [SerializeField] private Transform[] spawningPoints;
    [SerializeField] private int spawnNextEnemyAfterSeconds;
    private int currentEnemyToActivate;
    [SerializeField] private int secondWhenNextEnemyIsSpawned;

    [Header("Stage Properites")]
    [SerializeField] private int maxEnemyNumberInOneLvl = 30;
    private int maxNumberOfEnemiesInCurrentLvl;

    [Header("Other Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private LvlCounter lvlCounter;

    [Header("Spawned Enemies")]
    [SerializeField] private List<Enemy> enemies;

    private void Start()
    {
        PoolEnemies();
        OverrideSpawningSystemData();
    }

    private void Update()
    {
        if (CanActivateEnemy())
        {
            ActivateEnemyProcess();
            if(secondWhenNextEnemyIsSpawned - spawnNextEnemyAfterSeconds >= 0)
            {
                secondWhenNextEnemyIsSpawned -= spawnNextEnemyAfterSeconds;
            }
        }
    }

    private void ActivateEnemyProcess()
    {
        if (currentEnemyToActivate >= 0)
        {
            enemies[currentEnemyToActivate].gameObject.SetActive(true);
            enemies[currentEnemyToActivate].transform.position = RandomSpawnPointPosition();
            currentEnemyToActivate--;
        }
    }

    private bool CanActivateEnemy()
    {
        if (!timer.IsEndOfTime())
        {
            return timer.time <= secondWhenNextEnemyIsSpawned;
        }
        else { return false; }
    }

    public void OverrideSpawningSystemData()
    {
        AssignMaxAmmountOfEnemiesRelatedToLvlNumber();
        currentEnemyToActivate = enemies.Count - 1;
        maxNumberOfEnemiesInCurrentLvl = lvlCounter.lvlNumber;
        spawnNextEnemyAfterSeconds = (int)Mathf.Ceil(timer.StartTime / maxNumberOfEnemiesInCurrentLvl);
        secondWhenNextEnemyIsSpawned = timer.StartTime;
    }

    private void PoolEnemies()
    {
        for (int i = 0; i < maxEnemyNumberInOneLvl; i++)
        {
            enemies.Add(Instantiate(enemyPrefab, Vector2.zero, Quaternion.identity, transform));
            enemies[i].gameObject.SetActive(false);
        }
    }

    private Vector2 RandomSpawnPointPosition()
    {
        return spawningPoints[Random.Range(0, spawningPoints.Length)].position;
    }

    private void AssignMaxAmmountOfEnemiesRelatedToLvlNumber()
    {
        maxNumberOfEnemiesInCurrentLvl = lvlCounter.lvlNumber;
    }
}
