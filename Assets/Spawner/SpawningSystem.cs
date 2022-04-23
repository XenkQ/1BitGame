using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [SerializeField] private Transform[] _spawningPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _enemyNumberInStage;
    [SerializeField] private List<Enemy> enemies;
    private int _spawnAfter;
    private int _spawnAtSecond;
    private int _currentEnemy;

    private void Start()
    {
        PoolEnemies();
        _currentEnemy = enemies.Count - 1;
        _spawnAtSecond = _timer.StartTime;
        _spawnAfter = _timer.StartTime / _enemyNumberInStage;
    }

    private void PoolEnemies()
    {
        for (int i = 0; i < _enemyNumberInStage; i++)
        {
            enemies.Add(Instantiate(_enemyPrefab, RandomSpawnPoint(), Quaternion.identity, transform));
            enemies[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        //Debug.Log($"Spawn after: {_spawnAfter} | Timer {_timer.Time}");
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
            enemies[_currentEnemy].gameObject.SetActive(true);
            _currentEnemy--;
        }
    }

    private Vector2 RandomSpawnPoint()
    {
        return _spawningPoints[Random.Range(0, _spawningPoints.Length)].position;
    }
}
