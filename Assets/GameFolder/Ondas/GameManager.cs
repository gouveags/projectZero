using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Lista de inimigos que podem aparecer
    public Transform spawnPoint; // Ponto de spawn dos inimigos
    public float timeBetweenWaves = 10f; // Tempo entre as ondas
    private float countdown = 2f; // Contagem regressiva até a primeira onda
    private int waveNumber = 0; // Número da onda atualddd
   
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        Debug.Log("Onda #" + waveNumber + " chegou!");

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); // Intervalo entre a criação de cada inimigo
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
