using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrack : MonoBehaviour
{
    public AudioSource audioSouce;
    public AudioClip groundedSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSouce.PlayOneShot(groundedSound, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
