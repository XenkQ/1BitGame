using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private LvlCounter lvlCounter;
    [SerializeField] private Character character;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private PlayerOutOfLvlPoint nextLvlSpawner;
    [SerializeField] private EnemySpawningSystem enemySpawningSystem;
    [SerializeField] private EnemyVFXController enemyVFXController;
    [SerializeField] private TileMapsManager tileMapsMenager;

    [Header("Points")]
    [SerializeField] private NextLvlStartPoint nextLvlStartPoint;

    [Header("Sounds")]
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip endOfLvlSound;
    private bool endOfSoundWasPlayed = false;

    private void Start()
    {
        UnpauseGameIfPaused();
        nextLvlStartPoint.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        MoveToNextLvlIfPlayerIsOutOfLvl();
        PlayEndOfLvlSoundIfEndOfLvl();
    }

    private void MoveToNextLvlIfPlayerIsOutOfLvl()
    {
        if (nextLvlSpawner.PlayerOutOfLvl() && timer.IsEndOfTime())
        {
            MoveToNextLvlProcess();
        }
    }

    private void PlayEndOfLvlSoundIfEndOfLvl()
    {
        if (CanPlayEndOfLvlSound())
        {
            soundManager.PlaySound(endOfLvlSound);
            endOfSoundWasPlayed = true;
        }
    }

    private bool CanPlayEndOfLvlSound()
    {
        return timer.IsEndOfTime() && endOfSoundWasPlayed == false;
    }

    public void MoveToNextLvlProcess()
    {
        lvlCounter.increaseLvlNumber();
        character.TeleportToNewLvlPoint();
        enemyVFXController.RestartAllVFXProcess();
        nextLvlStartPoint.gameObject.SetActive(true);
        tileMapsMenager.EnteringNextLvlTileMapActivation();
        tileMapsMenager.ChangeCurrentObstacleTileMapForRandomObstacleTileMapProcess();
        timer.RestartTime();
        endOfSoundWasPlayed = false;
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
        GameTimeManager.UnpauseGameTime();
    }
}
