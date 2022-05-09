using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Phisic")]
    [HideInInspector] public Rigidbody2D characterRigidBody2D;

    [Header("Character Spawn Properties")]
    [SerializeField] private Transform newLvlSpawnPoint;
    [SerializeField] private Transform exitLvlPoint;
    [SerializeField] private float transformYOffset = -4.54f;

    [Header("Character Death Properties")]
    [SerializeField] private ParticleSystem deathParticle;
    [HideInInspector] public bool IsDead { get; private set; } = false;


    private void Awake()
    {
        characterRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CharacterDeathProcessIfIsDead();
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

    private void CharacterDeathProcessIfIsDead()
    {
        if(IsDead && spriteRenderer.gameObject.active != false)
        {
            spriteRenderer.gameObject.SetActive(false);
            MakeKinematicBodyType();
            deathParticle.Play();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            IsDead = true;
        }
    }
}
