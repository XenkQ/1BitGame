using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapsMenager : MonoBehaviour
{
    [Header("Deafult Tile Maps")]
    [SerializeField] private GameObject exitTileMap;
    [SerializeField] private GameObject deafultTileMap;
    [SerializeField] private GameObject enterTileMap;
    private bool isEndOfLvlTileMap = false;

    [Header("Obstacle Tile Maps")]
    [SerializeField] private GameObject[] tileMaps;
    private GameObject currentTileMap;

    [Header("Other Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private PlayerOutOfLvlPoint nextLvlPlayerSpawner;
    [SerializeField] private NextLvlStartPoint nextLvlStartPoint;

    private void Awake()
    {
        ChangeCurrentTileMapForRandomTileMapProcess();
    }

    private void FixedUpdate()
    {
        if (timer.IsEndOfTime())
        {
            EndOfLvlTileMapActivation();
            isEndOfLvlTileMap = true;
        }
        if(nextLvlPlayerSpawner.PlayerOutOfLvl())
        {
            EnteringNextLvlTileMapActivation();
        }
        if (timer.TimeIsSet)
        {
            isEndOfLvlTileMap = false;
        }
        //if(nextLvlStartPoint.PlayerInNextLvlStartingPoint())
        //{
        //    StartNextLvlTileMapActivation();
        //}
    }

    public void ChangeCurrentTileMapForRandomTileMapProcess()
    {
        if (currentTileMap != null)
        {
            DisableCurrentTileMap();
            ActivateRandomTileMap();
        }
        else { ActivateRandomTileMap(); }
    }

    private void DisableCurrentTileMap()
    {
        currentTileMap.SetActive(false);
    }

    private void ActivateRandomTileMap()
    {
        GameObject tileMap = RandomTileMap();
        tileMap.SetActive(true);
        currentTileMap = tileMap;
    }

    private GameObject RandomTileMap()
    {
        GameObject tileMap;

        do
        {
            tileMap = tileMaps[Random.Range(0, tileMaps.Length)];
        } while (tileMap.Equals(currentTileMap));

        return tileMap;
    }

    public void EndOfLvlTileMapActivation()
    {
        exitTileMap.SetActive(true);
        deafultTileMap.SetActive(false);
    }

    public void EnteringNextLvlTileMapActivation()
    {
        exitTileMap.SetActive(false);
        enterTileMap.SetActive(true);
    }

    public void StartNextLvlTileMapActivation()
    {
        enterTileMap.SetActive(false);
        deafultTileMap.SetActive(true);
    }
}
