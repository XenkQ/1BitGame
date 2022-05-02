using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFXController : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    private Transform spawnerVFX;

    //TODO: Make poll for particle VFX;

    private void Awake()
    {
        spawnerVFX = GameObject.FindGameObjectWithTag("VFXSpawner").transform;
    }

    public void SpawnEnemyDeathEffect()
    {
        Instantiate(deathVFX, transform.position, Quaternion.identity, spawnerVFX);
    }
}
