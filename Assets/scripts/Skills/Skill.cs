using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
 {
    public Transform storm;
    public Transform spike;

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
        if (collision.CompareTag("AttackUp"))
        {
            GetComponent<AttackCollider>().danoPlayer = 5;
            Destroy(gameObject);

        }
        if (collision.CompareTag("StormItem"))
        {
            storm.gameObject.SetActive(true);
            Destroy(gameObject);

        }
        
        if (collision.CompareTag("ShieldItem"))
        {
            collision.GetComponent<Character>().shieldActive = (true);
            Destroy(gameObject);
        }
        
        if (collision.CompareTag("Spike"))
        {
            spike.gameObject.SetActive(true);
            Destroy(gameObject);

        }
    }
}
