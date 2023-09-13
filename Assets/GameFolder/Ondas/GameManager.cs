using UnityEngine;
using UnityEngine.UI; // Importe a biblioteca UnityEngine.UI para acessar os componentes de UI
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Transform spawnPoint;
    public float timeBetweenWaves = 9f;
    private float countdown = 0f;
    private int waveNumber = 0;

    // Adicione estas duas variáveis para referenciar o texto da onda e do contador
    public Text waveText;
    public Text countText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        // Atualize o texto da contagem regressiva no Canvas
        countText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        waveText.text = "Onda: " + waveNumber ; // Atualize o texto da onda no Canvas
        Debug.Log("Onda #" + waveNumber + " chegou!");

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
    }
}
