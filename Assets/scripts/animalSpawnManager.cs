using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalSpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    float startDelay = 2;
    float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("spawnAnimal", startDelay, spawnInterval);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     spawnAnimal();
        // }
    }

    private void spawnAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
