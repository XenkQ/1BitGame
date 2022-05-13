using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
        if (nextLvlSpawner.PlayerOutOfLvl())
        {
            MoveToNextLvlProcess();
        }
        //if(nextLvlStartPoint.PlayerInNextLvlStartingPoint())
        //{
        //    StartNextLvlProcess();
        //}
    }

    public void MoveToNextLvlProcess()
    {
        lvlCounter.increaseLvlNumber();
        character.TeleportToNewLvlPoint();
        enemyVFXController.RestartAllVFXProcess();
        nextLvlStartPoint.gameObject.SetActive(true);
        tileMapsMenager.ChangeCurrentTileMapForRandomTileMapProcess();
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
        Debug.Log(character.IsDead + "|" + Time.timeScale + "|" + characterMovement.CanMove);
    }

    private void UnpauseGameIfPaused()
    {
        if (CanUnpause())
        {
            Time.timeScale = 1;
        }
    }

    private bool CanUnpause()
    {
        return Time.timeScale == 0;
    }
}
