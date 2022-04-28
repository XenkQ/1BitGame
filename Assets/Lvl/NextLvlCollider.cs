using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlCollider : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Timer _timer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if(_timer.IsEndOfTime())
            {
                _characterMovement.MovePlayerToNextLvl();
            }
        }
    }
}
