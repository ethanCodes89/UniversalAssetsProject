using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyAfterTime : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int amountToSpawn = 1;
    private float timeSinceStart = 0;
    private bool hasSpawned;
    private int numSpawned = 0;
    private void Update()
    {
        timeSinceStart += Time.deltaTime;
        if(timeSinceStart >= 5.0f && !hasSpawned && numSpawned < amountToSpawn)
        {
            Instantiate(EnemyPrefab, new Vector3(100, 100, numSpawned), Quaternion.identity);
            numSpawned++;

            if (numSpawned >= amountToSpawn) hasSpawned = true;
        }

    }
}
