using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float timeToSpawn;
    private float spawnCounter;

    public Transform minSpawn;
    public Transform maxSpawn;

    private void Start()
    {
        spawnCounter = timeToSpawn;
    }
    private void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;


            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation,transform);
        }
    }
    public Vector3 SelectSpawnPoint() 
    {
        Vector3 spawnPoint = Vector3.zero;
        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;
        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > 0.5f)
                spawnPoint.x = maxSpawn.position.x;
            else
                spawnPoint.x = minSpawn.position.x;
        }
        else 
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > 0.5f)
                spawnPoint.y = maxSpawn.position.y;
            else
                spawnPoint.y = minSpawn.position.y;
        }


        return spawnPoint;
    }

}
