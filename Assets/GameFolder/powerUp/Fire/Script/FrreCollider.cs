using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrreCollider : MonoBehaviour
{
    public Transform cam;
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
            collision.GetComponent<Character>().life--;
            collision.GetComponent<Character>().Skin.GetComponent<Animator>().Play("Hit", -1);
            cam.GetComponent<Animator>().Play("CamPlayerDamge", -1);

        }
    }
}
