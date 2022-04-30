using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    private Rigidbody2D enemyRigidBody;
    private Vector3 lastVelocity;

    [Header("Other Scripts")]
    private Timer timer;

    [Header("VFX")]
    [SerializeField] private GameObject particleEffect;
    private Transform spawnerVFX;

    private void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        spawnerVFX = GameObject.FindGameObjectWithTag("VFXSpawner").transform;
    }

    private void OnEnable()
    {
        StartCoroutine(AddForceVelocity());
    }

    private void Update()
    {
        lastVelocity = enemyRigidBody.velocity;
        KeepVelocity();
        DieProcess();
    }

    private void KeepVelocity()
    {
        if (enemyRigidBody.velocity == Vector2.zero)
        {
            StartCoroutine(AddForceVelocity());
        }
    }

    private void DieProcess()
    {
        if (CanDie())
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity, spawnerVFX);
            Destroy(this.gameObject);
        }
    }

    private bool CanDie()
    {
        if (timer.IsEndOfTime())
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
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal).normalized;
        enemyRigidBody.velocity = direction * Mathf.Max(speed, 0f);
    }

    private IEnumerator AddForceVelocity()
    {
        yield return new WaitForFixedUpdate();
        AddRandomForceToRigidBody();
    }

    private void AddRandomForceToRigidBody()
    {
        enemyRigidBody.AddForce(speed * Time.deltaTime * Random.insideUnitCircle.normalized);
    }
}
