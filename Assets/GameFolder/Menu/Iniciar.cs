using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar : MonoBehaviour
{
    public float loadingDelay; // Tempo de atraso na cena de Loading em segundos.

    // Mantenha a assinatura original da função LoadScene.
    public void LoadScene(int indexScene)
    {
        StartCoroutine(LoadGame(indexScene));
    }

    IEnumerator LoadGame(int indexScene)
    {
        // Carrega a cena de Loading pelo índice.
        SceneManager.LoadScene(indexScene);

        // Aguarda o tempo de atraso definido antes de passar para a cena de gameplay.
        yield return new WaitForSeconds(loadingDelay);

        // Carrega a cena de gameplay pelo índice.
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo");
    }
}
