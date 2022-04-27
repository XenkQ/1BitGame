using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlMenager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Timer _timer;
    [SerializeField] private LvlCounter _lvlCounter;

    [Header("TileMaps")]
    [SerializeField] private GameObject _exitTileMap;
    [SerializeField] private GameObject _deafultTileMap;
    [SerializeField] private GameObject _enterTileMap;

    [Header("Colliders")]
    [SerializeField] private BoxCollider2D _nextLvlCollider;

    private void Update()
    {
        if(_timer.Time <= 0)
        {
            _exitTileMap.SetActive(true);
            _deafultTileMap.SetActive(false);
        }
    }

    //TODO: if player in out of camera view enter animation and load functions of new lvl

    public void LoadNextLvl()
    {
        _nextLvlCollider.enabled = true;
        _exitTileMap.SetActive(false);
        _enterTileMap.SetActive(true);
        _lvlCounter.increaseLvlNumber();
    }
}
