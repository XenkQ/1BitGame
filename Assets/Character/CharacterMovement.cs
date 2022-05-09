using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Properites")]
    [SerializeField] private float speed = 8f;
    private float horizontal;
    private bool canMove = true;
    public bool CanMove { get; private set; } = true;

    [Header("Animations")]
    private Animator animator;

    [Header("Other Components")]
    [SerializeField] private Camera mainCamera;

    [Header("Other Scripts")]
    private Character character;

    private void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        MakeCanMoveOnCharacterDeath();
    }

    private void FixedUpdate()
    {
        MoveProcess();
    }

    private void MakeCanMoveOnCharacterDeath()
    {
        if (character.IsDead)
        {
            canMove = false;
        }
    }

    private void MoveProcess()
    {
        if (canMove)
        {
            AnimationsControl();
            MovePlayer(horizontal);
        }
    }

    private void MovePlayer(float inputX)
    {
        character.characterRigidBody2D.velocity = new Vector3(inputX * speed, character.characterRigidBody2D.velocity.y);
    }

    public void MovePlayerToNextLvl()
    {
        canMove = false;
        animator.SetBool("Running", true);
        character.MakeKinematicBodyType();
        MovePlayer(1);
    }

    public void ResetCharacterMovement()
    {
        canMove = true;
        character.MakeDynamicBodyType();
        animator.SetBool("Running", false);
        MovePlayer(0);
    }

    private void AnimationsControl()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
