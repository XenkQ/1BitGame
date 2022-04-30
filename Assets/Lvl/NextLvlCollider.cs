using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlCollider : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Timer timer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (timer.IsEndOfTime())
            {
                characterMovement.MovePlayerToNextLvl();
            }
        }
    }
}
