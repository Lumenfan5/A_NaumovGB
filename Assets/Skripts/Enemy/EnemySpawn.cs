using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy EnemyPrefab;
    [SerializeField] private float spawnStep = 1f;
    private const float LifeTime = .5f;
    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            var enemy = Instantiate(EnemyPrefab, transform);
            nextSpawnTime = Time.time + spawnStep;
            Destroy(enemy.gameObject, LifeTime);
        }
    }
}
