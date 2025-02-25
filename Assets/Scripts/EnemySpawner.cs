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



    public GameObject enemyToSpawn;
    private float spawnCounter;

    public Transform minSpawn;
    public Transform maxSpawn;


    private float gameTime;
    private void Start()
    {
        spawnCounter = initalSpawnInterval;
    }
    private void Update()
    {
        spawnCounter -= Time.deltaTime;
        gameTime += Time.deltaTime;

        if (spawnCounter <= 0)
        {
            spawnCounter = GetCurrentSpawnInterval();
            //Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation,transform);
            GameObject silm = ObjPoolManager.instance.GetObj("Silm");
            silm.transform.position = SelectSpawnPoint();
        }
        Debug.Log("ÏÖÔÚË¢¹ÖÆµÂÊ: " + GetCurrentSpawnInterval());
    }

    public float GetCurrentSpawnInterval() 
    {
        float t = Mathf.Clamp01(gameTime / maxDifficultyTime);
        float difficulty = Mathf.Pow(t, accelerationFactor*10);
        float currentInterval = Mathf.Lerp(initalSpawnInterval,minSpawnInterval, difficulty);
        return currentInterval;
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
