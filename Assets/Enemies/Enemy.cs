using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyVFXController))]
public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    private Rigidbody2D enemyRigidBody;
    private Vector3 lastVelocity;

    [Header("Other Scripts")]
    private Timer timer;
    private EnemyVFXController controllerVFX;

    private void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        controllerVFX = GetComponent<EnemyVFXController>();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal).normalized;
        enemyRigidBody.velocity = direction * Mathf.Max(speed, 0f);
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
            controllerVFX.SpawnEnemyDeathEffect();
            gameObject.SetActive(false);
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
