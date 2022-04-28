using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 8f;
    private Rigidbody2D _rb;
    private Vector3 _lastVelocity;

    [Header("Other Scripts")]
    private Timer _timer;

    [Header("VFX")]
    [SerializeField] private GameObject _particleEffect;
    private Transform _spawnerVFX;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        _spawnerVFX = GameObject.FindGameObjectWithTag("VFXSpawner").transform;
    }

    private void OnEnable()
    {
        StartCoroutine(AddForceVelocity());
    }

    private void Update()
    {
        _lastVelocity = _rb.velocity;
        KeepVelocity();
        DieProcess();
    }

    private void KeepVelocity()
    {
        if (_rb.velocity == Vector2.zero)
        {
            StartCoroutine(AddForceVelocity());
        }
    }

    private void DieProcess()
    {
        if (CanDie())
        {
            Instantiate(_particleEffect, transform.position, Quaternion.identity, _spawnerVFX);
            Destroy(this.gameObject);
        }
    }

    private bool CanDie()
    {
        if (_timer.IsEndOfTime())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var _speed = _lastVelocity.magnitude;
        var _direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal).normalized;
        _rb.velocity = _direction * Mathf.Max(_speed, 0f);
        Debug.Log("Collision");
    }

    private IEnumerator AddForceVelocity()
    {
        yield return new WaitForFixedUpdate();
        _rb.AddForce(_speed * Time.deltaTime * Random.insideUnitCircle.normalized);
    }
}
