using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlStartPoint : MonoBehaviour
{
    [SerializeField] private LvlMenager lvlMenager;
    [SerializeField] private Timer timer;
    [SerializeField] private Character character;

    private void FixedUpdate()
    {
        if (character.transform.position.x >= transform.position.x && timer.timeIsSet == false)
        {
            lvlMenager.StartNextLvlProcess();
        }
    }
}
