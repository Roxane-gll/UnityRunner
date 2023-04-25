using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleSpawner : MonoBehaviour
{
   [SerializeField] Transform[] spawnPoints;
   [SerializeField] GameObject obstaclePrefabs;
   [SerializeField] public int nbObstacle = 1;

   [Header("Bonus")]
   [SerializeField] GameObject bonusPrefab;
   [SerializeField] float timeToBonus = 5.5f;
   [SerializeField] float timeBetweenBonus = 10f;

   [Header("Timers")]
   [SerializeField] float timeToSpawn = 2f;
   [SerializeField] float timeBetweenWaves = 1f;


   void Update()
   {
    if (Time.time >= timeToSpawn) {
        SpawnObstacle();
        timeToSpawn = Time.time + timeBetweenWaves;
    }
    if (Time.time >= timeToBonus) {
        SpawnBonus();
        timeToBonus = Time.time + timeBetweenBonus;
    }
   }

    void SpawnObstacle()
    {
        List<int> randomIndexs = new List<int>();
        while (randomIndexs.Count < nbObstacle) {
            int newInt = Random.Range(0, spawnPoints.Length);
            if (randomIndexs.Contains(newInt) == false) {
                randomIndexs.Add(newInt);
            }
        }
        for (int spawn = 0; spawn < spawnPoints.Length; spawn++)
        {
            if (randomIndexs.Contains(spawn) == true) {
                Instantiate(obstaclePrefabs.transform, spawnPoints[spawn].position, Quaternion.identity);
            }
        }
    }

    void SpawnBonus() {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int spawn = 0; spawn < spawnPoints.Length; spawn++)
        {
            if (randomIndex == spawn) {
                Instantiate(bonusPrefab.transform, spawnPoints[spawn].position, Quaternion.identity);
            }
        }
    }
}
