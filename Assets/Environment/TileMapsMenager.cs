using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapsMenager : MonoBehaviour
{
    [Header("Deafult Tile Maps")]
    [SerializeField] private GameObject exitTileMap;
    [SerializeField] private GameObject deafultTileMap;
    [SerializeField] private GameObject enterTileMap;

    [Header("Obstacle Tile Maps")]
    [SerializeField] private GameObject[] tileMaps;
    private GameObject currentTileMap;

    [Header("Other Scripts")]
    [SerializeField] private Timer timer;

    private void Awake()
    {
        ChangeCurrentTileMapForRandomTileMapProcess();
    }

    private void Update()
    {
        if (timer.IsEndOfTime())
        {
            EndOfLvlTileMapActivation();
        }
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

    private void DisableCurrentTileMap()
    {
        currentTileMap.SetActive(false);
    }

    public void EndOfLvlTileMapActivation()
    {

        exitTileMap.SetActive(true);
        deafultTileMap.SetActive(false);
    }

    public void EnteringNewLvlTileMapActivation()
    {
        exitTileMap.SetActive(false);
        enterTileMap.SetActive(true);
    }

    public void StartNewLvlTileMapActivation()
    {

        enterTileMap.SetActive(false);
        deafultTileMap.SetActive(true);
    }
}
