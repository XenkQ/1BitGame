using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [SerializeField] private Vector2[] _spawningPoints;
    [SerializeField] private int _enemyNumberInStage;
    private Enemy _enemyPrefab;
    private Timer _timer = new Timer();


    private void Update()
    {
        if(CanSpawnEnemy())
        { 
            SpawnEnemy();
        }
    }

    private bool CanSpawnEnemy()
    {
        return _timer.Time == _timer.StartTime / _enemyNumberInStage ? true : false;
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, RandomSpawnPoint(), Quaternion.identity, transform);
    }

    private Vector2 RandomSpawnPoint()
    {
        return _spawningPoints[Random.Range(0, _spawningPoints.Length)];
    }
}
