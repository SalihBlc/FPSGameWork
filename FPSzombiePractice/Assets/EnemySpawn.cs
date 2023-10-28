using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemyCount = 20;
    private List<GameObject> zombiess = new List<GameObject>();
    void Start()
    {
        SpawnEnemies(maxEnemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiess.Count < maxEnemyCount)
        {
            int remainingEnemies = maxEnemyCount - zombiess.Count;
            SpawnEnemies(remainingEnemies);
        }

    }
    public void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            zombiess.Add(enemy);
        }
    }
}
