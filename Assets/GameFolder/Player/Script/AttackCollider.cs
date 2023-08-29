using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    public Transform player;

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
                
            }
            else {

                collision.GetComponent<Character>().life -= 2;
                collision.GetComponent<Character>().Skin.GetComponent<Animator>().Play("Hit");

            }
        }

    }




}
