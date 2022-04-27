using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 8f;
    private float _horizontal;
    private Rigidbody2D _rb;
    private bool _canMove = true;
    private bool _visibleByCamera = true;

    [Header("Animations")]
    private Animator _animator;

    [Header("Other Components")]
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        MoveProcess();
    }

    private void MoveProcess()
    {
        if (_canMove)
        {
            AnimationsControl();
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        _rb.velocity = new Vector3(_horizontal * _speed, _rb.velocity.y);
    }

    private void OnBecameInvisible()
    {
        _visibleByCamera = false;
    }

    //TODO: Make smooth movement to next lvl
    public void MovePlayerToNextLvl()
    {
        _canMove = false;
        _animator.SetBool("Running", true);
        //while(_visibleByCamera)
        //{
        //    _rb.velocity = new Vector3(1 * _speed, _rb.velocity.y);
        //}
        _rb.velocity = new Vector3(1 * _speed, _rb.velocity.y);
    }

    private void AnimationsControl()
    {
        if (Input.GetButton("Horizontal"))
        {
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }
    }
}
