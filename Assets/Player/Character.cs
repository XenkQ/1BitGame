using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D characterRigidBody2D;
    [SerializeField] private Transform newLvlSpawnPoint;
    [SerializeField] private Transform exitLvlPoint;
    [SerializeField] private float transformYOffset = -4.54f;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Awake()
    {
        characterRigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void MakeKinematicBodyType()
    {
        characterRigidBody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    public void MakeDynamicBodyType()
    {
        characterRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    public void TeleportToNewLvlPoint()
    {
        transform.position = new Vector2(newLvlSpawnPoint.position.x, transformYOffset);
    }
}
