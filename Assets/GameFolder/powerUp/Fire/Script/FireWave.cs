using UnityEngine;

public class FireWave : MonoBehaviour
{
    public GameObject powerWave;  // Coloca o objeto da animação do poder aqui
    public float powerCooldown = 5.0f;  // Tempo de recarga do poder
    private float cooldownTimer = 0.0f;
    private bool canUsePower = true;

    // Update é chamado a cada quadro
    void Update()
    {
        // Verifica se o poder está em recarga
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            canUsePower = true;
        }

       
        // Agora, verifica se o jogador apertou o botão pra ativar o poder (por exemplo, "F" no teclado ou um botão no controle)
        if (canUsePower &&  Input.GetKeyDown(KeyCode.F))
        {
            ActivatePower();
        }
    }

    void ActivatePower()
    {
        // Ativa a animação do poder
        
        powerWave.GetComponent<Animator>().Play("fire");
        // Aqui você pode colocar o código que faz o poder acontecer, tipo causar dano, empurrar inimigos, etc.

        // Começa a contagem da recarga
        cooldownTimer = powerCooldown;

        // E impede o uso do poder durante a recarga
        canUsePower = false;
    }
}
