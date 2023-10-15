using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> bossPrefabs;
    public GameObject storePrefab;
    public List<GameObject> spawnPoint3Enemies;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnStore;
    public Transform bossSpawnPoint;
    public float timeBetweenWaves = 3f;
    private float countdown;
    public int waveNumber = 10;
    private int enemiesToSpawn;
    public int enemiesRemaining;
    private bool isBossWave = false;
    private bool isStoreWave = false;
    private bool isGamePaused = false; // Adicione este campo para controlar a pausa

    public Text CoinCountText;
    public Text waveText;
    public Text countText;
    public GameObject pausePanel; // Adicione um painel para o menu de pausa

    private float tempoDecorrido = 0f;
    public float tempoPasso = 1f;

    void Start()
    {
        UpdateCountdown();
        StartNewWave();
    }

    void Update()
    {
        if (!isGamePaused) // Só atualiza o jogo se não estiver pausado
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

            if (enemies.Length <= 0 && !isStoreWave)
            {
                enemiesRemaining = 0;
            }

            if (isBossWave == true && enemies.Length == 0)
            {
                isBossWave = false;
            }

            tempoDecorrido += Time.deltaTime;
        }

        int horas = Mathf.FloorToInt(tempoDecorrido / 3600);
        int minutos = Mathf.FloorToInt((tempoDecorrido % 3600) / 60);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60);

        waveText.text = "Onda: " + waveNumber + " | " + horas.ToString("D2") + ":" + minutos.ToString("D2") + ":" + segundos.ToString("D2");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0; // Pausa o tempo do jogo
        pausePanel.SetActive(true); // Ativa o painel de pausa
    }

    void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1; // Retoma o tempo do jogo
        pausePanel.SetActive(false); // Desativa o painel de pausa
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnTransform = Random.Range(0f, 1f) > 0.5f ? spawnPoint : spawnPoint2;
            SpawnEnemy(spawnTransform);
            SpawnEnemy3();
            float randomSpawnDelay = Random.Range(1, 3);
            yield return new WaitForSeconds(randomSpawnDelay);
        }
    }

    IEnumerator SpawnStoreWave()
    {
        if (isStoreWave)
        {
            yield break; // Sai da função se a wave da loja já estiver ativa.
        }

        isStoreWave = true; // Marca que a wave da loja está ativa.

        // Spawn da loja.
        GameObject store = Instantiate(storePrefab, spawnStore.position, spawnStore.rotation);

        // Aguarda alguns segundos antes de destruir a loja.
        yield return new WaitForSeconds(5f);

        // Destrói o game object da loja.
        Destroy(store);

        // Espera até que o objeto da loja tenha sido destruído.
        while (store != null)
        {
            yield return null;
        }

        isStoreWave = false; // Marca que a wave da loja não está mais ativa.

        // Reinicia as waves normais.
        enemiesToSpawn++;
        StartCoroutine(SpawnWave());
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
        if (!isStoreWave) // Verifica se não é a wave da loja.
        {
            waveNumber++; // Incrementa o contador de ondas apenas se não for a wave da loja.
            waveText.text = "Onda: " + waveNumber;
        }

        countdown = timeBetweenWaves;
        UpdateCountdown();

        if (isStoreWave == false && waveNumber > 0 && waveNumber % 10 == 0)
        {
            isBossWave = true;
            SpawnBoss();
        }
        else if (isBossWave == false && waveNumber > 0 && waveNumber % 5 == 0)
        {
            StartCoroutine(SpawnStoreWave());
        }
        else if (isBossWave == false && isStoreWave == false)
        {
            enemiesToSpawn++;
            StartCoroutine(SpawnWave());
        }
    }

    void UpdateCountdown()
    {
        countText.text = Mathf.Round(countdown).ToString();
    }
}
