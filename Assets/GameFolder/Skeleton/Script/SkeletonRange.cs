using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Caso precisemos de um cooldown nos ataques:
/* 
    public float attackCooldown = 0.5f; // The time between attacks in seconds
    private float currentCooldown = 0.0f; // Timer to track cooldown

    private Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the cooldown timer
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentCooldown <= 0)
        {
            // Play the attack animation
            animator.Play("SkeletonAttack", -1);

            // Set the cooldown timer to the attackCooldown value
            currentCooldown = attackCooldown;
        }
    } */

public class SkeletonRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            transform.parent.GetComponent<Animator>().Play("SkeletonAttack", -1);

        }
    }
}
