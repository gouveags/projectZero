using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public AudioSource audioSouce;
    public AudioClip groundedSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            audioSouce.PlayOneShot(groundedSound, 0.5f);

        }
    }
}
