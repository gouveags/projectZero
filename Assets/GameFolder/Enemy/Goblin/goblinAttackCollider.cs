using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAttackCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            bool shieldActive = collision.GetComponent<Character>().shieldActive;

            if (shieldActive)
            {
                // Causar dano ao escudo
                collision.GetComponent<Character>().ShieldDamage(Random.Range(1, 2));

            }
            else
            {
                // Causar dano ao jogador
                collision.GetComponent<Character>().PlayerDamage(Random.Range(1, 2));
            }

        }
    }
}
