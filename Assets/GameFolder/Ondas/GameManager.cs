using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> bossPrefabs;
    public List<GameObject> spawnPoint3Enemies; // Novo array de inimigos para spawnPoint3.
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform bossSpawnPoint;
    public float timeBetweenWaves = 3f;
    private float countdown;
    private int waveNumber = 0;
    private int enemiesToSpawn;
    public int enemiesRemaining;
    private bool isBossWave = false;

    public Text CoinCountText;
    public Text waveText;
    public Text countText;

    void Start()
    {
        UpdateCountdown();
        StartNewWave();
    }

    void Update()
    {
        if (enemiesRemaining == 0)
        {
            countdown -= Time.deltaTime;
            UpdateCountdown();

            if (countdown <= 0f)
            {
                StartNewWave();
            }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length <= 0)
        {
            enemiesRemaining = 0;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnTransform = Random.Range(0f, 1f) > 0.5f ? spawnPoint : spawnPoint2; // Escolhe aleatoriamente entre spawnPoint e spawnPoint2.

            SpawnEnemy(spawnTransform);
            SpawnEnemy3();

            float randomSpawnDelay = Random.Range(0.1f, 1.0f); // Tempo aleatório entre spawns.
            yield return new WaitForSeconds(randomSpawnDelay);
        }
    }

    void SpawnEnemy(Transform spawnTransform)
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomIndex], spawnTransform.position, spawnTransform.rotation);
        enemiesRemaining++;
    }

    void SpawnEnemy3()
    {
        int randomIndex = Random.Range(0, spawnPoint3Enemies.Count);
        Instantiate(spawnPoint3Enemies[randomIndex], spawnPoint3.position, spawnPoint3.rotation);
        enemiesRemaining++;
    }

    void SpawnBoss()
    {
        int randomIndex = Random.Range(0, bossPrefabs.Count);
        Instantiate(bossPrefabs[randomIndex], bossSpawnPoint.position, bossSpawnPoint.rotation);
        enemiesRemaining++;
    }

    void StartNewWave()
    {
        countdown = timeBetweenWaves;
        UpdateCountdown();

        if (waveNumber > 0 && waveNumber % 10 == 0)
        {
            isBossWave = true;
            SpawnBoss();
        }
        else
        {
            isBossWave = false;
            enemiesToSpawn++;
            StartCoroutine(SpawnWave());
        }

        waveNumber++;
        waveText.text = "Onda: " + waveNumber;
    }

    void UpdateCountdown()
    {
        countText.text = Mathf.Round(countdown).ToString();
    }

    public void EnemyDestroyed()
    {
        if (enemiesRemaining <= 0)
        {
            StartNewWave();
        }
    }
}
