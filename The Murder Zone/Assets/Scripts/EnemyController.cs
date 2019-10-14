using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPreFab;
    List<GameObject> enemies = new List<GameObject>();
    GameObject lastSpawnedEnemy;

    private int enemiesToSpawn;

    private void Start()
    {
        enemiesToSpawn = 20;
        GameObject enemy = Instantiate(enemyPreFab, transform);
        lastSpawnedEnemy = enemy;
        enemies.Add(enemy);
    }

    private void Update()
    {
        List<GameObject> removeEnemies = enemies.Where(enemy => enemy.GetComponent<Enemy>().GetNodeIndex()
                                                        >= enemy.GetComponent<Enemy>().GetMaxIndex()).ToList();
        List<GameObject> killEnemies = enemies.Where(enemy => enemy.GetComponent<Enemy>().GetHealth() <= 0f).ToList();

        foreach (GameObject enemy in killEnemies)
        {
            enemies.Remove(enemy);
            Destroy(enemy);
        }


        foreach (GameObject enemy in removeEnemies)
        {
            enemies.Remove(enemy);
            Destroy(enemy);
        }

        if (enemiesToSpawn > 0 && lastSpawnedEnemy.GetComponent<Enemy>().GetNodeIndex() > 0)
        {
            GameObject newEnemy = Instantiate(enemyPreFab, transform);
            lastSpawnedEnemy = newEnemy;
            enemiesToSpawn -= 1;
            enemies.Add(newEnemy);
        }
    }
}
