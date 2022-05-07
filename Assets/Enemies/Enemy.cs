using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float velocityMagnitude;
    private Rigidbody2D enemyRigidBody;
    private Vector3 lastVelocity;
    private float expectedEnemyRigidBodyVelocity = 6f;

    [Header("Other Scripts")]
    private Timer timer;
    private EnemyVFXController controllerVFX;

    private void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        controllerVFX = GameObject.FindGameObjectWithTag("VFXSpawner").GetComponent<EnemyVFXController>();
    }

    private void OnEnable()
    {
        StartCoroutine(AddForceVelocity());
    }

    private void Update()
    {
        EnemyMovingProcess();
        DieIfCanDie();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        BounceEnemyOfAnObject(collisionInfo);
    }

    private void BounceEnemyOfAnObject(Collision2D collisionInfo)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collisionInfo.contacts[0].normal).normalized;
        enemyRigidBody.velocity = direction * Mathf.Max(speed, 0f);
    }

    private void EnemyMovingProcess()
    {
        AssignLastVelocity();
        AssignVelocityMagnitude();
        MakeTheRigidBodyVelocityAlwaysTheSameAsStaticVelocity();
        AddVelocityIfEnemyStopped();
    }

    private void AssignLastVelocity()
    {
        lastVelocity = enemyRigidBody.velocity;
    }

    private void AssignVelocityMagnitude()
    {
        velocityMagnitude = enemyRigidBody.velocity.magnitude;
    }

    private void MakeTheRigidBodyVelocityAlwaysTheSameAsStaticVelocity()
    {
        if (velocityMagnitude != expectedEnemyRigidBodyVelocity)
        {
            enemyRigidBody.velocity = lastVelocity.normalized * expectedEnemyRigidBodyVelocity;
        }
    }

    private void AddVelocityIfEnemyStopped()
    {
        if (EnemyStopped())
        {
            StartCoroutine(AddForceVelocity());
        }
    }

    private bool EnemyStopped()
    {
        return enemyRigidBody.velocity == Vector2.zero;
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

    private void DieIfCanDie()
    {
        if (CanDie())
        {
            controllerVFX.SpawnEnemyDeathEffect(transform.position);
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
}
