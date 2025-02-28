using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float initalSpawnInterval;
    public float minSpawnInterval;
    public float accelerationFactor;
    public float maxDifficultyTime;

    public Transform player;

    public GameObject enemyToSpawn;
    private float spawnCounter;

    private Vector3 minSpawn;
    private Vector3 maxSpawn;

    public Vector3 maxSpawnOffset;
    public Vector3 minSpawnOffset;
    private float gameTime;
    private void Start()
    {
        spawnCounter = initalSpawnInterval;
        player = FindAnyObjectByType<Player>().transform;
    }
    private void Update()
    {
            
        spawnCounter -= Time.deltaTime;
        gameTime += Time.deltaTime;
        minSpawn = minSpawnOffset+ player.transform.position;
        maxSpawn = maxSpawnOffset + player.transform.position;
        if (spawnCounter <= 0)
        {
            spawnCounter = GetCurrentSpawnInterval();            
            GameObject silm = ObjPoolManager.instance.GetObj("Silm");
            silm.transform.position = SelectSpawnPoint();
        }
        //Debug.Log(GetCurrentSpawnInterval());
        
    }

    public float GetCurrentSpawnInterval()  //刷怪间隔计算
    {
        float t = Mathf.Clamp01(gameTime / maxDifficultyTime);
        float difficulty = Mathf.Pow(t, accelerationFactor*10);
        float currentInterval = Mathf.Lerp(initalSpawnInterval,minSpawnInterval, difficulty);
        return currentInterval;
    }


    public Vector3 SelectSpawnPoint() //怪物刷新点计算
    {
        Vector3 spawnPoint = Vector3.zero;
        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;
        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.y, maxSpawn.y);
            if (Random.Range(0f, 1f) > 0.5f)
                spawnPoint.x = maxSpawn.x;
            else
                spawnPoint.x = minSpawn.x;
        }
        else 
        {
            spawnPoint.x = Random.Range(minSpawn.x, maxSpawn.x);
            if (Random.Range(0f, 1f) > 0.5f)
                spawnPoint.y = maxSpawn.y;
            else
                spawnPoint.y = minSpawn.y;
        }


        return spawnPoint;
    }

}
