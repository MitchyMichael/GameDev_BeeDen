using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy(GameObject enemy)
    {
        // GameObject newEnemy = Instantiate(enemyPrefab) as GameObject;
        // newEnemy.transform.position = new Vector3(12, Random.Range(-3, 3), 0);
        GameObject newEnemy = Instantiate(enemy, new Vector3(10, Random.Range(-3f, 3), 0), Quaternion.identity);
    }

    IEnumerator enemyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            spawnEnemy(enemyPrefab);
        }
    }
}
