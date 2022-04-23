using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    private Rigidbody2D _rb;
    private Vector3 _lastVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //TODO: Make Velocity OnEnable Working Alike For All Enemies
        StartCoroutine(AddVelocityAtEnable());
    }

    private void Update()
    {
        _lastVelocity = _rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var _speed = _lastVelocity.magnitude;
        var _direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal).normalized;
        _rb.velocity = _direction * Mathf.Max(_speed, 0f);
        Debug.Log("Collision");
    }

    private IEnumerator AddVelocityAtEnable()
    {
        yield return new WaitForFixedUpdate();
        _rb.AddForce(_speed * Time.deltaTime * Random.insideUnitCircle.normalized);
    }
}
