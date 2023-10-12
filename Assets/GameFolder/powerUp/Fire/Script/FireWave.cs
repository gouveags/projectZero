using UnityEngine;

public class FireWave : MonoBehaviour
{
    public GameObject powerWave;  // Coloca o objeto da anima��o do poder aqui
    public float powerCooldown = 5.0f;  // Tempo de recarga do poder
    private float cooldownTimer = 0.0f;
    private bool canUsePower = true;

    // Update � chamado a cada quadro
    void Update()
    {
        // Verifica se o poder est� em recarga
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            canUsePower = true;
        }

       
        // Agora, verifica se o jogador apertou o bot�o pra ativar o poder (por exemplo, "F" no teclado ou um bot�o no controle)
        if (canUsePower &&  Input.GetKeyDown(KeyCode.F))
        {
            ActivatePower();
        }
    }

    void ActivatePower()
    {
        // Ativa a anima��o do poder
        
        powerWave.GetComponent<Animator>().Play("fire");
        // Aqui voc� pode colocar o c�digo que faz o poder acontecer, tipo causar dano, empurrar inimigos, etc.

        // Come�a a contagem da recarga
        cooldownTimer = powerCooldown;

        // E impede o uso do poder durante a recarga
        canUsePower = false;
    }
}
