using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();

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
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }
}
