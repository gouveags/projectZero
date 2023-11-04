using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
 {
    public Transform storm;
    public Transform spike;
    public Transform attack;

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
            attack.GetComponent<AttackCollider>().danoPlayer = 5;
        

        }
        if (collision.CompareTag("StormItem"))
        {
            storm.gameObject.SetActive(true);

        }
        
        if (collision.CompareTag("ShieldItem"))
        {
            GetComponent<Character>().shieldActive = (true);
        }
        
        if (collision.CompareTag("Spike"))
        {
            spike.gameObject.SetActive(true);

        }
    }
}
