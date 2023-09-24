using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour
{
    public GameObject enemyBalls;
    public GameObject powerupPrefab;
    float spawnRange = 9;
    public int enemyCount;
    public int waveNumber=1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ballCreate", 2, 30);

        float ranX = Random.Range(-spawnRange, spawnRange);
        float ranZ = Random.Range(-spawnRange, spawnRange);
        Instantiate(powerupPrefab, new Vector3(ranX, 0, ranZ), powerupPrefab.transform.rotation);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<enemyBalls>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);

            float ranX = Random.Range(-spawnRange, spawnRange);
            float ranZ = Random.Range(-spawnRange, spawnRange);
            Instantiate(powerupPrefab, new Vector3(ranX, 0, ranZ), powerupPrefab.transform.rotation);
        }
    }

    void ballCreate()
    {
        spawnEnemyWave(waveNumber);
    }

    private void spawnEnemyWave(int v)
    {
        for (int i = 0; i < v; i++)
        {
            float ranX = Random.Range(-spawnRange, spawnRange);
            float ranZ = Random.Range(-spawnRange, spawnRange);
            Instantiate(enemyBalls, new Vector3(ranX, 0, ranZ), enemyBalls.transform.rotation);
        }
    }
}
