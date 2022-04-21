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

    [SerializeField] private SpriteRenderer _playerSprite;
    private float _horizontal;
    private Rigidbody2D _rb;
    private bool _runningAnimIsOn = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_horizontal * _speed, _rb.velocity.y);
        if (_rb.velocity.x != 0)
        {
            StartCoroutine(RunningAnim());
        }
        else
        {
            _playerSprite.sprite = _playerDeafultSprite;
        }
    }

    private IEnumerator RunningAnim()
    {
        if (!_runningAnimIsOn)
        {
            _runningAnimIsOn = true;
            for (int i = 0; _rb.velocity.x != 0; i++)
            {
                if (i > _runningAnimationSprites.Length - 1) { i = 0; }
                _playerSprite.sprite = _runningAnimationSprites[i];
                yield return new WaitForSeconds(_animationSpeed);
            }
            _runningAnimIsOn = false;
        }
    }
}
