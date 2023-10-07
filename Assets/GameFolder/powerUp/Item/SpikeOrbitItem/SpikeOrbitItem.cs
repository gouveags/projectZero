using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeOrbitItem : MonoBehaviour
{
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
        if (collision.CompareTag("Player"))
        {
            spike.gameObject.SetActive(true);
            Destroy(gameObject);

        }
    }
}
