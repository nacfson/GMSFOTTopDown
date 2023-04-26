using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnRadius;

    private void Start()
    {
        InvokeRepeating("SpawnBoss", 5.5f, spawnInterval);
    }

    private void SpawnBoss()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnPointIndex].position + Random.insideUnitSphere * spawnRadius;
        GameObject prefab = prefabs[spawnPointIndex];
        GameObject boss = PoolList.instance.Pop(prefab.name, spawnPosition);
        if (boss != null)
        {
            Invoke("PushBoss", 1.3f);
        }
    }

    private void PushBoss()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            PoolList.instance.Push(boss);
        }
    }
}
