using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    public Transform player;
    public Transform cam;
    public AudioSource audioSouce;
    public AudioClip groundedSound;

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
        
        if (collision.CompareTag("Enemy"))
        {
            if(player.GetComponent<PlayerController>().comboNum == 1) { 
            
                collision.GetComponent<Character>().life--;
                collision.GetComponent<Character>().Skin.GetComponent<Animator>().Play("Hit",-1);
                cam.GetComponent<Animator>().Play("CamPlayerDamge", -1);
                audioSouce.PlayOneShot(groundedSound, 0.05f);

            }
            else {

                collision.GetComponent<Character>().life -= 2;
                collision.GetComponent<Character>().Skin.GetComponent<Animator>().Play("Hit");
                cam.GetComponent<Animator>().Play("CamPlayerDamge", -1);
                audioSouce.PlayOneShot(groundedSound, 0.05f);

            }
        }

    }




}
