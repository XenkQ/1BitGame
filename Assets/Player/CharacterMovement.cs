using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Sprite[] _runningAnimationSprites;
    [SerializeField] private Sprite _playerDeafultSprite;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private LayerMask _wallMask;
    [SerializeField] private float _rayLength = 1f;
    private Animator _animator;

    [SerializeField] private SpriteRenderer _playerSprite;
    private float _horizontal;
    private Rigidbody2D _rb;
    private bool _runningAnimIsOn = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, _rayLength, _wallMask);
        Debug.DrawRay(transform.position, Vector2.right * _rayLength, Color.green);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, _rayLength, _wallMask);
        Debug.DrawRay(transform.position, Vector2.left * _rayLength, Color.red);

        if (hitLeft.transform != null)
        {
            Debug.Log($"Left: {hitLeft.transform.tag}");
        }

        if (hitRight.transform != null)
        {
            Debug.Log($"Right: {hitRight.transform.tag}");
        }

        Debug.Log(_horizontal);

        if (_horizontal != 0)
        {
            _animator.SetBool("Running", true);
            //if (hitLeft.transform != null && hitLeft.transform.tag == "Wall" || hitRight.transform && hitRight.transform.tag == "Wall")
            //{
            //    _animator.SetBool("Running", false);
            //}
        }
        else
        {
            _animator.SetBool("Running", false);
        }

        _rb.velocity = new Vector3(_horizontal * _speed, _rb.velocity.y);
    }

    //private IEnumerator RunningAnim()
    //{
    //    if (!_runningAnimIsOn)
    //    {
    //        _runningAnimIsOn = true;
    //        for (int i = 0; _rb.velocity.x != 0; i++)
    //        {
    //            if (i > _runningAnimationSprites.Length - 1) { i = 0; }
    //            _playerSprite.sprite = _runningAnimationSprites[i];
    //            yield return new WaitForSeconds(_animationSpeed);
    //        }
    //        _runningAnimIsOn = false;
    //    }
    //}
}
