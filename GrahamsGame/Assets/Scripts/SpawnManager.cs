using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Zombie;
    private float startDelay = 10;
    private float repeatRate = 10;
    EnemyBehaviour enemy;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnCounter = 0;
    private float level = 0;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
        enemy = GameObject.Find("EnemyBehaviour").GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeX, spawnRangeX));
        Instantiate(Zombie, spawnPos, Zombie.transform.rotation);
        
        spawnCounter++;
        enemy.speed += 10;
    }

    void Level()
    {
        spawnCounter = level;
    }


}
