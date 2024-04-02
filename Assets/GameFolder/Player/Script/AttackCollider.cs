using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    public Transform player;
    public Transform cam;
    public AudioSource audioSouce;
    public AudioClip groundedSound;
    public int danoPlayer = 0;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            if (player.GetComponent<PlayerController>().comboNum == 1) {

                StartCoroutine(DelayHit(collision));
                collision.GetComponent<CharacterEnemmy>().life -= (danoPlayer + Random.Range(1, 2));  
                collision.GetComponent<CharacterEnemmy>().Skin.GetComponent<Animator>().Play("Hit", -1);
                cam.GetComponent<Animator>().Play("CamPlayerDamage", -1);
                audioSouce.PlayOneShot(groundedSound, 0.5f);

            }
            else {

                StartCoroutine(DelayHit(collision));
                collision.GetComponent<CharacterEnemmy>().life -= (danoPlayer + Random.Range(2, 3));
                collision.GetComponent<CharacterEnemmy>().Skin.GetComponent<Animator>().Play("Hit");
                cam.GetComponent<Animator>().Play("CamPlayerDamage", -1);
                audioSouce.PlayOneShot(groundedSound, 0.5f);

            }
        }

    }
    IEnumerator DelayHit(Collider2D collision)
    {
        // Desabilitar o componente enemyWalk associado ao objeto 'collision'
        collision.GetComponent<enemyWalk>().enabled = false;
        collision.GetComponent<CharacterEnemmy>().Skin.GetComponentInChildren<CircleCollider2D>().enabled = false;
        collision.GetComponent<CharacterEnemmy>().Skin.GetComponent<Animator>().Play("Hit", -1);
        yield return new WaitForSeconds(1);
        // Habilitar o componente enemyWalk associado ao objeto 'collision'
      
        collision.GetComponent<enemyWalk>().enabled = true;
        collision.GetComponent<CharacterEnemmy>().Skin.GetComponentInChildren<CircleCollider2D>().enabled = true;
    }

}
