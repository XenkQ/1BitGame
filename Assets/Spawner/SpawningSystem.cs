using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [SerializeField] private Transform[] _spawningPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _enemyNumberInStage;
    private int _spawnAfter;
    private int _spawnAtSecond;

    private void Start()
    {
        _spawnAtSecond = _timer.StartTime;
        _spawnAfter = _timer.StartTime / _enemyNumberInStage;
    }

    private void Update()
    {
        Debug.Log($"Spawn after: {_spawnAfter} | Timer {_timer.Time} | ");
        if (CanSpawnEnemy())
        {
            SpawnEnemy();
            _spawnAtSecond -= _spawnAfter;
        }
    }

    private bool CanSpawnEnemy()
    {
        return _timer.Time == _spawnAtSecond;
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, RandomSpawnPoint(), Quaternion.identity, transform);
    }

    private Vector2 RandomSpawnPoint()
    {
        return _spawningPoints[Random.Range(0, _spawningPoints.Length)].position;
    }
}
