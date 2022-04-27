using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvlCollider : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            _characterMovement.MovePlayerToNextLvl();
        }
    }
}
