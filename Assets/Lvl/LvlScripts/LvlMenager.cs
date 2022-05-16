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
    [SerializeField] private PlayerOutOfLvlPoint nextLvlSpawner;
    [SerializeField] private EnemySpawningSystem enemySpawningSystem;
    [SerializeField] private EnemyVFXController enemyVFXController;
    [SerializeField] private TileMapsMenager tileMapsMenager;
    [SerializeField] private GUIMenager gUIMenager;

    [Header("Points")]
    [SerializeField] private NextLvlStartPoint nextLvlStartPoint;

    private void Start()
    {
        UnpauseGameIfPaused();
        nextLvlStartPoint.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        MoveToNextLvlIfPlayerIsOutOfLvl();
    }

    private void MoveToNextLvlIfPlayerIsOutOfLvl()
    {
        if (nextLvlSpawner.PlayerOutOfLvl() && timer.IsEndOfTime())
        {
            MoveToNextLvlProcess();
        }
    }

    public void MoveToNextLvlProcess()
    {
        lvlCounter.increaseLvlNumber();
        character.TeleportToNewLvlPoint();
        enemyVFXController.RestartAllVFXProcess();
        nextLvlStartPoint.gameObject.SetActive(true);
        tileMapsMenager.ChangeCurrentObstacleTileMapForRandomObstacleTileMapProcess();
        timer.RestartTime();
    }

    public void StartNextLvlProcess()
    {
        tileMapsMenager.StartNextLvlTileMapActivation();
        characterMovement.ResetCharacterMovement();
        nextLvlStartPoint.gameObject.SetActive(false);
        enemySpawningSystem.OverrideSpawningSystemData();
    }

    public void RestartGameProcess()
    {
        SceneManager.LoadScene(0);
    }

    private void UnpauseGameIfPaused()
    {
        GameTimeMenager.UnpauseGameTime();
    }
}
