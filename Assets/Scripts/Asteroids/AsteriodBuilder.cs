using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodBuilder : MonoBehaviour
{
    [SerializeField] Vector3 size;
    [SerializeField] GameObject[] asteroids;
    [SerializeField] float spawnTime = 1f;

    float elapsed = 0;
    private void Start()
    {
        SpawnAsteroids();
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed > spawnTime)
        {
            SpawnAsteroids();
            elapsed = 0;
        }
            
    }

    private void SpawnAsteroids()
    {
        Vector3 position = transform.position + new Vector3(Random.Range(-size.x / 2.0f, size.x / 2.0f), Random.Range(-size.y / 2.0f, size.y / 2.0f), 0f);
        if(Random.Range(0, 10) > 3)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], position, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, size);
    }
}
