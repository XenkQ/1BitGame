using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFXController : MonoBehaviour
{
    [Header("Particle effects")]
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField] private List<ParticleSystem> allEnemiesDeathParticleEffectsToSpawn;

    [Header("Other Scripts")]
    [SerializeField] private EnemySpawningSystem EnemySpawningSystem;

    private int lastIndexOfAllDeathParticles;

    private void Awake()
    {
        PoolAllEnemiesDeathEffects();
    }

    private void Start()
    {
        AssignLastIndexOfParticles();
    }

    public void RestartAllVFXProcess()
    {
        DisableAllParticlesFromCurrentLvl();
        AssignLastIndexOfParticles();
    }

    private void DisableAllParticlesFromCurrentLvl()
    {
        foreach (ParticleSystem particleSystem in allEnemiesDeathParticleEffectsToSpawn)
        {
            particleSystem.transform.gameObject.SetActive(false);
        }
    }

    private void AssignLastIndexOfParticles()
    {
        lastIndexOfAllDeathParticles = allEnemiesDeathParticleEffectsToSpawn.Count - 1;
    }

    public void SpawnEnemyDeathEffect(Vector2 enemyPos)
    {
        allEnemiesDeathParticleEffectsToSpawn[lastIndexOfAllDeathParticles].gameObject.SetActive(true);
        allEnemiesDeathParticleEffectsToSpawn[lastIndexOfAllDeathParticles].transform.position = enemyPos;
        allEnemiesDeathParticleEffectsToSpawn[lastIndexOfAllDeathParticles].GetComponent<ParticleSystem>().Play();
        lastIndexOfAllDeathParticles--;
    }

    private void PoolAllEnemiesDeathEffects()
    {
        for (int i = 0; i < EnemySpawningSystem.MaxEnemyNumberInOneLvl; i++)
        {
            allEnemiesDeathParticleEffectsToSpawn.Add(Instantiate(deathVFX, Vector2.zero, Quaternion.identity, transform));
            allEnemiesDeathParticleEffectsToSpawn[i].gameObject.SetActive(false);
        }
    }
}
