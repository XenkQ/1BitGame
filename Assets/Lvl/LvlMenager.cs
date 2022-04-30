using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlMenager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private LvlCounter lvlCounter;
    [SerializeField] private Character character;
    [SerializeField] private NextLvlPlayerSpawner newLvlSpawner;

    [Header("TileMaps")]
    [SerializeField] private GameObject exitTileMap;
    [SerializeField] private GameObject deafultTileMap;
    [SerializeField] private GameObject enterTileMap;

    [Header("Colliders Objects")]
    [SerializeField] private GameObject nextLvlCollider;

    private void Update()
    {
        if (timer.IsEndOfTime())
        {
            exitTileMap.SetActive(true);
            deafultTileMap.SetActive(false);
            character.MakeKinematicBodyType();
        }

        if (newLvlSpawner.PlayerOutOfLvl() && timer.timeIsSet)
        {
            LoadNextLvl();
        }
    }

    public void LoadNextLvl()
    {
        exitTileMap.SetActive(false);
        enterTileMap.SetActive(true);
        nextLvlCollider.SetActive(true);
        lvlCounter.increaseLvlNumber();
        character.TeleportToNewLvlPoint();
        timer.RestartTime();
    }
}
