using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] spawnPoints;
    public int start = 10;
    public int spawnRate = 3;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");

        for (int i = 0; i <= start; i++)
        {
            spawnEnemy();
        }

        StartCoroutine(spawnOverTime());
    }

    IEnumerator spawnOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        int randomInt = Random.Range(0, spawnPoints.Length - 1);
        Instantiate(enemy);
        enemy.transform.position = spawnPoints[randomInt].transform.position;
    }

}
