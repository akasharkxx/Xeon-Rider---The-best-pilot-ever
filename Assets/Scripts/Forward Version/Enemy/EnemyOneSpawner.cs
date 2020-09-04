using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawnOfOneType, timeBetweenDifferentEnemy;
    [SerializeField] private int numberOfEnemies;

    private float elapsedTime;
    private int enemiesSpawned, enemyIndex;
    private bool canSpawn;

    private void Start()
    {
        elapsedTime = 0;
        enemiesSpawned = 0;
        enemyIndex = 0;
        canSpawn = true;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(canSpawn && elapsedTime >= timeBetweenSpawnOfOneType && 
            enemiesSpawned < numberOfEnemies && enemyIndex < enemyPrefab.Length)
        {
            SpawnEnemy(enemyIndex);
        }
        if(enemiesSpawned == numberOfEnemies)
        {
            enemyIndex++;
            enemiesSpawned = 0;
            elapsedTime = 0;
            canSpawn = false;
        }
        if(elapsedTime >= timeBetweenDifferentEnemy)
        {
            canSpawn = true;
        }
        if(enemyIndex == enemyPrefab.Length)
        {
            this.enabled = false;
        }
    }

    private void SpawnEnemy(int enemyTypeIndex)
    {
        GameObject enemy = Instantiate(enemyPrefab[enemyTypeIndex], spawnPoint.position, Quaternion.identity);
        enemy.transform.SetParent(spawnPoint);
        enemiesSpawned++;
        elapsedTime = 0;
    }
}
