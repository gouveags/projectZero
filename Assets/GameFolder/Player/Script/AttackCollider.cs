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
            if(player.GetComponent<PlayerController>().comboNum == 1) { 
            
                collision.GetComponent<CharacterEnemmy>().life-= (danoPlayer + Random.Range(1,2)) ;
                collision.GetComponent<CharacterEnemmy>().Skin.GetComponent<Animator>().Play("Hit",-1);
                cam.GetComponent<Animator>().Play("CamPlayerDamage", -1);
                audioSouce.PlayOneShot(groundedSound, 0.5f);

            }
            else {

                collision.GetComponent<CharacterEnemmy>().life -= (danoPlayer + Random.Range(2,3));
                collision.GetComponent<CharacterEnemmy>().Skin.GetComponent<Animator>().Play("Hit");
                cam.GetComponent<Animator>().Play("CamPlayerDamage", -1);
                audioSouce.PlayOneShot(groundedSound, 0.5f);

            }
        }

    }

}
