using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameManager gameManager; // Referência ao GameManager para controlar as ondas.
    public GameObject shopObject;   // O objeto da loja.
    public float shopDuration = 10f; // Duração da onda da loja em segundos.
    private bool isShopWaveActive = false;

    void Start()
    {
        // Certifique-se de que a loja esteja desativada no início do jogo.
        shopObject.SetActive(false);
    }

    void Update()
    {
        // Verifique se a onda da loja está ativa.
        if (isShopWaveActive)
        {
            // Se a onda da loja está ativa, conte o tempo.
            shopDuration -= Time.deltaTime;

            // Se a duração da loja acabou, desative a loja e retome as ondas.
            if (shopDuration <= 0f)
            {
                DisableShopWave();
            }
        }
    }

    public void StartShopWave()
    {
        // Pausar as ondas usando o GameManager.
       

        // Ativar o objeto da loja.
        shopObject.SetActive(true);
        isShopWaveActive = true;

        // Definir a duração da loja.
        shopDuration = 10f;
    }

    public void DisableShopWave()
    {
        // Desativar o objeto da loja.
        shopObject.SetActive(false);
        isShopWaveActive = false;

        // Retomar as ondas usando o GameManager.
       
    }
}
