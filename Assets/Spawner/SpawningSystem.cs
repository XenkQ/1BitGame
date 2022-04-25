using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Enemy _enemyPrefab;

    [Header("Spawning Properites")]
    [SerializeField] private Transform[] _spawningPoints;
    private int _spawnAfter;
    private int _spawnAtSecond;
    private int _currentEnemy;

    [Header("Stage Properites")]
    [SerializeField] private int _enemyNumberInStage;

    [Header("Other Scripts")]
    [SerializeField] private Timer _timer;

    [Header("Spawned Enemies")]
    [SerializeField] private List<Enemy> _enemies;

    private void Start()
    {
        PoolEnemies();
        _currentEnemy = _enemies.Count - 1;
        _spawnAtSecond = _timer.StartTime;
        _spawnAfter = _timer.StartTime / _enemyNumberInStage;
    }

    private void PoolEnemies()
    {
        for (int i = 0; i < _enemyNumberInStage; i++)
        {
            _enemies.Add(Instantiate(_enemyPrefab, RandomSpawnPoint(), Quaternion.identity, transform));
            _enemies[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (CanSpawnEnemy())
        {
            EnableEnemy();
            _spawnAtSecond -= _spawnAfter;
        }
    }

    private bool CanSpawnEnemy()
    {
        return _timer.Time == _spawnAtSecond;
    }

    private void EnableEnemy()
    {
        if(_currentEnemy >= 0)
        {
            _enemies[_currentEnemy].gameObject.SetActive(true);
            _currentEnemy--;
        }
    }

    private Vector2 RandomSpawnPoint()
    {
        return _spawningPoints[Random.Range(0, _spawningPoints.Length)].position;
    }
}
