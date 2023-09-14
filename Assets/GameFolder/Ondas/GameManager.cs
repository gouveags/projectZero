using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Transform spawnPoint;
    public float timeBetweenWaves = 9f;
    private float countdown = 0f;
    private int waveNumber = 0;
    private int enemiesToSpawn = 1;
    public int enemiesRemaining = 0; // Quantidade de inimigos restantes na cena.
  


    public Text waveText;
    public Text countText;

    void Start()
    {
        UpdateCountdown();
        // Inicialmente, não há inimigos na cena, então podemos começar a contagem.
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
       
        if (enemies.Length <= 0 )

        {
            enemiesRemaining = 0;
            
        }

    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
        enemiesRemaining++;
    }

    void StartNewWave()
    {
       
        // Reinicia a contagem regressiva.
        countdown = timeBetweenWaves;
        UpdateCountdown();
       
        enemiesToSpawn++; // Aumenta a quantidade de inimigos na próxima onda.
        StartCoroutine(SpawnWave());
      
        waveNumber++;
        waveText.text = "Onda: " + waveNumber;
        Debug.Log("Onda #" + waveNumber + " chegou!");
    }

    void UpdateCountdown()
    {
        countText.text = Mathf.Round(countdown).ToString();
    }

    // Função para chamar quando um inimigo é destruído.
    public void EnemyDestroyed()
    {

        // Verifica se todos os inimigos foram destruídos.
        if (enemiesRemaining <= 0)
        {
            StartNewWave(); // Inicia uma nova onda.
        }
    }
}
