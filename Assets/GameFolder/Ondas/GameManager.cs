using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> bossPrefabs;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform bossSpawnPoint;
    public float timeBetweenWaves = 3f;
    private float countdown;
    private int waveNumber = 0;
    private int enemiesToSpawn;
    public int enemiesRemaining; // Quantidade de inimigos restantes na cena.
    private bool isBossWave = false;

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
            SpawnEnemy();
            SpawnEnemy2();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
        enemiesRemaining++;
    }

    void SpawnEnemy2()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomIndex], spawnPoint2.position, spawnPoint2.rotation);
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

        if (waveNumber > 0 && waveNumber % 10 == 0) // A bossfight ocorre a cada 10 ondas após a primeira.
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
        Debug.Log("Onda #" + waveNumber + " chegou!");
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
