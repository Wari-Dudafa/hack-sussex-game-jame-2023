using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject[] spawnPoints;
    public int start = 10;
    public int spawnRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        StartCoroutine(spawnOverTime());
    }

    IEnumerator spawnOverTime()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < start - 1; i++)
        {
            spawnEnemy();
        }

        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        int randomInt = Random.Range(0, spawnPoints.Length - 1);
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = spawnPoints[randomInt].transform.position;
    }
}
