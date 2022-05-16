using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningSystem : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private Enemy enemyPrefab;

    [Header("Spawning")]
    [SerializeField] private Transform[] spawningPoints;
    [SerializeField] private float spawnNextEnemyAfterSeconds;
    [SerializeField] private float secondWhenNextEnemyIsSpawned;
    [SerializeField] private int currentEnemyToSpawn;
    [HideInInspector] public int CurrentEnemyToSpawn { get { return currentEnemyToSpawn; } }

    [Header("Stage")]
    [SerializeField] private int maxEnemyNumberInOneLvl = 30;
    [HideInInspector] public int MaxEnemyNumberInOneLvl { get { return maxEnemyNumberInOneLvl; } }
    private int maxNumberOfEnemiesInCurrentLvl;
    private int minEnemyIndex = 0;

    [Header("Other Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private LvlCounter lvlCounter;

    [Header("Spawned Enemies")]
    [SerializeField] private List<Enemy> enemies;

    private void Awake()
    {
        PoolEnemies();
    }

    private void Start()
    {
        OverrideSpawningSystemData();
    }

    private void Update()
    {
        SpawningEnemyProcess();
    }

    private void SpawningEnemyProcess()
    {
        if (CanActivateEnemy())
        {
            ActivateEnemy();
            SetCurrentEnemyPositionToRandomPoint();
            CalculateWhenNextEnemyIsSpawned();
            currentEnemyToSpawn--;
        }
    }

    private bool CanActivateEnemy()
    {
        if (!timer.IsEndOfTime() && currentEnemyToSpawn >= minEnemyIndex)
        {
            return timer.Time <= secondWhenNextEnemyIsSpawned;
        }
        else { return false; }
    }

    private void ActivateEnemy()
    {
        if (currentEnemyToSpawn >= 0)
        {
            enemies[currentEnemyToSpawn].gameObject.SetActive(true);
        }
    }

    private void SetCurrentEnemyPositionToRandomPoint()
    {
        enemies[currentEnemyToSpawn].transform.position = RandomSpawnPointPosition();
    }

    private Vector2 RandomSpawnPointPosition()
    {
        return spawningPoints[Random.Range(0, spawningPoints.Length)].position;
    }

    private void CalculateWhenNextEnemyIsSpawned()
    {
        if (secondWhenNextEnemyIsSpawned - spawnNextEnemyAfterSeconds >= 0)
        {
            secondWhenNextEnemyIsSpawned = Mathf.Round(secondWhenNextEnemyIsSpawned - spawnNextEnemyAfterSeconds);
        }
    }

    public void OverrideSpawningSystemData()
    {
        AssignMaxAmmountOfEnemiesRelatedToLvlNumber();
        AssignLastEnemyAsCurrentEnemy();
        AssignMaxNumberOfEnemiesInCurrentLvlBasedOnLvlNumber();
        CalculateTimeAfterNextEnemyIsSpawned();
        ResetWhenNextEnemyIsSpawned();
        CalculateMinEnemyIndexInCurrentLvl();
    }

    private void AssignMaxAmmountOfEnemiesRelatedToLvlNumber()
    {
        maxNumberOfEnemiesInCurrentLvl = lvlCounter.LvlNumber;
    }

    private void AssignLastEnemyAsCurrentEnemy()
    {
        if (enemies.Count > 0)
        {
            currentEnemyToSpawn = enemies.Count - 1;
        }
    }
    private void AssignMaxNumberOfEnemiesInCurrentLvlBasedOnLvlNumber()
    {
        maxNumberOfEnemiesInCurrentLvl = lvlCounter.LvlNumber;
    }

    private void CalculateTimeAfterNextEnemyIsSpawned()
    {
        spawnNextEnemyAfterSeconds = (float)timer.StartTime / maxNumberOfEnemiesInCurrentLvl;
    }

    private void ResetWhenNextEnemyIsSpawned()
    {
        secondWhenNextEnemyIsSpawned = timer.StartTime;
    }

    private void CalculateMinEnemyIndexInCurrentLvl()
    {
        minEnemyIndex = maxEnemyNumberInOneLvl - maxNumberOfEnemiesInCurrentLvl;
    }

    private void PoolEnemies()
    {
        for (int i = 0; i < maxEnemyNumberInOneLvl; i++)
        {
            enemies.Add(Instantiate(enemyPrefab, Vector2.zero, Quaternion.identity, transform));
            enemies[i].gameObject.SetActive(false);
        }
    }

    public void DisableAllEnemies()
    {
        foreach(Enemy enemy in enemies)
        {
            if(enemy.gameObject.active == true)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }
}
