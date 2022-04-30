using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlPlayerSpawner : MonoBehaviour
{
    [SerializeField] Character character;

    public bool PlayerOutOfLvl()
    {
        if (character.transform.position.x >= transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
