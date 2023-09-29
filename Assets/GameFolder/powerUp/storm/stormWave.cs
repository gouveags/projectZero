using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stormWave : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float velPlataform;
    public bool goRight;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goRight == true)
        {

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;

            }

            transform.position = Vector2.MoveTowards(transform.position, b.position, velPlataform * Time.deltaTime);
        }
        else
        {

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;

            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, velPlataform * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Entrei");
         
            collision.GetComponent<Character>().life--;
            collision.GetComponent<Character>().Skin.GetComponent<Animator>().Play("Hit", -1);
            cam.GetComponent<Animator>().Play("CamPlayerDamge", -1);

        }
    }
}
