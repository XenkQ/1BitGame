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
    [SerializeField] private EnemySpawningSystem EnemySpawningSystem;
    [SerializeField] private EnemyVFXController enemyVFXController;
    [SerializeField] private TileMapsMenager tileMapsMenager;
    [SerializeField] private GUIMenager gUIMenager;

    [Header("Points")]
    [SerializeField] private GameObject nextLvlStartPoint;

    private void Start()
    {
        nextLvlStartPoint.SetActive(false);
    }

    private void Update()
    {
        if (newLvlSpawner.PlayerOutOfLvl())
        {
            timer.RestartTime();
        }

        if (newLvlSpawner.PlayerOutOfLvl() && timer.timeIsSet)
        {
            MoveToNextLvlProcess();
        }
    }

    public void MoveToNextLvlProcess()
    {
        tileMapsMenager.EnteringNewLvlTileMapActivation();
        lvlCounter.increaseLvlNumber();
        character.TeleportToNewLvlPoint();
        enemyVFXController.RestartAllVFXProcess();
        nextLvlStartPoint.SetActive(true);
        tileMapsMenager.ChangeCurrentTileMapForRandomTileMapProcess();
    }

    public void StartNextLvlProcess()
    {
        tileMapsMenager.StartNewLvlTileMapActivation();
        characterMovement.ResetCharacterMovement();
        nextLvlStartPoint.SetActive(false);
        EnemySpawningSystem.OverrideSpawningSystemData();
    }

    public void RestartGameProcess()
    {
        UnpauseGameIfPaused();
        lvlCounter.RestartLvlNumber();
        timer.RestartTime();
        character.CharacterRestartProcess();
        tileMapsMenager.ChangeCurrentTileMapForRandomTileMapProcess();
        gUIMenager.DisableAllGUI();
    }

    private void UnpauseGameIfPaused()
    {
        if (Time.timeScale == 0)
        {
            UnpauseGame();
        }
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
