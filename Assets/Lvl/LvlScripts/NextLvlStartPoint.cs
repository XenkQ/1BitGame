using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlStartPoint : MonoBehaviour
{
    [SerializeField] private LvlManager lvlManager;
    [SerializeField] private Character character;

    private void FixedUpdate()
    {
        if (PlayerInNextLvlStartingPoint())
        {
            lvlManager.StartNextLvlProcess();
        }
    }

    public bool PlayerInNextLvlStartingPoint()
    {
        return character.transform.position.x >= transform.position.x;
    }
}
