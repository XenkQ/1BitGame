using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    private float horizontal;
    private Rigidbody2D playerRigidBody;
    private bool canMove = true;
    private bool visibleByCamera = true;

    [Header("Animations")]
    private Animator animator;

    [Header("Other Components")]
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        MoveProcess();
    }

    private void MoveProcess()
    {
        if (canMove)
        {
            AnimationsControl();
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        playerRigidBody.velocity = new Vector3(horizontal * speed, playerRigidBody.velocity.y);
    }

    private void OnBecameInvisible()
    {
        visibleByCamera = false;
    }

    //TODO: Make smooth movement to next lvl
    public void MovePlayerToNextLvl()
    {
        canMove = false;
        animator.SetBool("Running", true);
        //while(visibleByCamera)
        //{
        //    playerRigidBody.velocity = new Vector3(1 * speed, playerRigidBody.velocity.y);
        //}
        playerRigidBody.velocity = new Vector3(1 * speed, playerRigidBody.velocity.y);
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
