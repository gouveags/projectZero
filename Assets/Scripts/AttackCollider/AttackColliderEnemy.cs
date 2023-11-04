using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderEnemy : MonoBehaviour
{
    public int damageMin;
    public int damageMax;
    int dano;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dano = Random.Range(damageMin, damageMax);

            bool shieldActive = collision.GetComponent<Character>().shieldActive;

            if (shieldActive)
            {
                // Causar dano ao escudo
                collision.GetComponent<Character>().ShieldDamage(dano);

            }
            else
            {
                // Causar dano ao jogador
                collision.GetComponent<Character>().PlayerDamage(dano);
            }

        }
    }
}
