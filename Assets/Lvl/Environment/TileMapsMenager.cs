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
    private bool firstObstacleMapAssigned = false;

    [Header("Other Scripts")]
    [SerializeField] private Timer timer;
    [SerializeField] private PlayerOutOfLvlPoint nextLvlPlayerSpawner;
    [SerializeField] private NextLvlStartPoint nextLvlStartPoint;
    [SerializeField] private InLvlTextMenager inLvlTextMenager;

    private void Update()
    {
        AssignFirstRandomObstacleTileMapIfPressAnyKeyToStartIsDisable();
    }

    private void FixedUpdate()
    {
        ActiveEndOfLvlTileMapIfIsEndOfTime();

        ActiveEnteringNextLvlTileMapIfPlayerIsOutOfLvl();
    }

    private void ActiveEndOfLvlTileMapIfIsEndOfTime()
    {
        if (timer.IsEndOfTime())
        {
            EndOfLvlTileMapActivation();
        }
    }

    private void ActiveEnteringNextLvlTileMapIfPlayerIsOutOfLvl()
    {
        if (nextLvlPlayerSpawner.PlayerOutOfLvl())
        {
            EnteringNextLvlTileMapActivation();
        }
    }

    private void AssignFirstRandomObstacleTileMapIfPressAnyKeyToStartIsDisable()
    {
        if (!inLvlTextMenager.IsPressAnyKeyToStartActive() && firstObstacleMapAssigned == false)
        {
            ChangeCurrentObstacleTileMapForRandomObstacleTileMapProcess();
            firstObstacleMapAssigned = true;
        }
    }

    public void ChangeCurrentObstacleTileMapForRandomObstacleTileMapProcess()
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
        GameObject tileMap = GetRandomObstacleTileMap();
        tileMap.SetActive(true);
        currentTileMap = tileMap;
    }

    private GameObject GetRandomObstacleTileMap()
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
