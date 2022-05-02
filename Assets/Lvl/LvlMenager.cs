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
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private NextLvlPlayerSpawner newLvlSpawner;
    [SerializeField] private SpawningSystem spawningSystem;
    [SerializeField] private SpawnedVFXController spawnedVFXController;

    [Header("TileMaps")]
    [SerializeField] private GameObject exitTileMap;
    [SerializeField] private GameObject deafultTileMap;
    [SerializeField] private GameObject enterTileMap;

    [Header("Points")]
    [SerializeField] private GameObject nextLvlStartPoint;

    private void Start()
    {
        nextLvlStartPoint.SetActive(false);
    }

    private void Update()
    {
        if (timer.IsEndOfTime())
        {
            ExitTileMapActivationProcess();
        }

        if (newLvlSpawner.PlayerOutOfLvl())
        {
            timer.RestartTime();
        }

        if (newLvlSpawner.PlayerOutOfLvl() && timer.timeIsSet)
        {
            MoveToNextLvlProcess();
        }
    }

    private void ExitTileMapActivationProcess()
    {
        exitTileMap.SetActive(true);
        deafultTileMap.SetActive(false);
    }

    public void MoveToNextLvlProcess()
    {
        EnterTileMapActivationProcess();
        lvlCounter.increaseLvlNumber();
        character.TeleportToNewLvlPoint();
        spawnedVFXController.ClearAllVFXFromCurrentLvl();
        nextLvlStartPoint.SetActive(true);
    }

    private void EnterTileMapActivationProcess()
    {
        exitTileMap.SetActive(false);
        enterTileMap.SetActive(true);
    }

    public void StartNextLvlProcess()
    {
        Debug.Log("Next lvl");
        DeafultTileMapActivationProcess();
        characterMovement.ResetCharacterMovement();
        nextLvlStartPoint.SetActive(false);
        spawningSystem.OverrideSpawningSystemData();
    }

    private void DeafultTileMapActivationProcess()
    {
        enterTileMap.SetActive(false);
        deafultTileMap.SetActive(true);
    }
}
