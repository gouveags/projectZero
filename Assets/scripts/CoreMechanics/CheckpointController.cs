using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoreMechanics
{
    public class CheckpointController : MonoBehaviour
    {
     
        public static Vector2 currentCheckpoint = Vector2.zero;

        // Start is called before the first frame update
        void Start()
        {
            if (gameObject.tag == "StartCheckpoint")
            {
                currentCheckpoint = transform.position;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                currentCheckpoint = transform.position;
               
            }
        }
      

    }

}