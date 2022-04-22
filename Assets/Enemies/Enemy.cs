using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    private Rigidbody2D _rb;
    private Vector3 lastVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.AddForce(_speed * Time.deltaTime * Random.insideUnitCircle.normalized);
    }

    private void Update()
    {
        lastVelocity = _rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var _speed = lastVelocity.magnitude;
        var _direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal).normalized;
        _rb.velocity = _direction * Mathf.Max(_speed, 0f);
        Debug.Log("Collision");
    }
}
