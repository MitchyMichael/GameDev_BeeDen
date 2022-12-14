using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;
    public TextMeshProUGUI wavename;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private bool canAnimate = false;

    private void Start()
    {
        PlayerPrefs.SetString("Difficulty", SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        spawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0)
        {
            if(currentWaveNumber + 1 != waves.Length)
            {
                if(canAnimate)
                {
                    wavename.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }
            }
        }
    }

    void spawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void spawnWave()
    {
        if(canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
                canAnimate = true;
            }
        }
    }
}
