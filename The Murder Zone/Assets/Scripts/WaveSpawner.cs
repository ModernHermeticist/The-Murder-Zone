using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    GameObject lastSpawnedEnemy;

    EnemyController enemyController;

    public float timeBetweenWaves = 30f;
    private float countDown = 5f;

    public Text waveCountDownText;

    private int waveIndex = 0;

    private int enemiesToSpawn = 2;

    private void Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
    }

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex += 1;
        for (int i = 0; i < enemiesToSpawn * waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        lastSpawnedEnemy = enemy;
        enemyController.AddEnemy(enemy);
    }
}
