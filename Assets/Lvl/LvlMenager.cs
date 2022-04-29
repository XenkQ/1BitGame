using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlMenager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private LvlCounter lvlCounter;

    [Header("TileMaps")]
    [SerializeField] private GameObject exitTileMap;
    [SerializeField] private GameObject deafultTileMap;
    [SerializeField] private GameObject enterTileMap;

    [Header("Colliders Objects")]
    [SerializeField] private GameObject nextLvlCollider;

    private void Update()
    {
        if(timer.IsEndOfTime())
        {
            exitTileMap.SetActive(true);
            deafultTileMap.SetActive(false);
        }
    }

    //TODO: if player in out of camera view enter animation and load functions of new lvl

    public void LoadNextLvl()
    {
        exitTileMap.SetActive(false);
        enterTileMap.SetActive(true);
        nextLvlCollider.SetActive(true);
        lvlCounter.increaseLvlNumber();
    }
}
