using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class fireOne : MonoBehaviour
{
    public Transform FireBall;
    int Onda;
    public int nOnda;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Onda = GetComponent<GameManager>().waveNumber;

        if (Onda <= nOnda)
        {
            FireBall.gameObject.SetActive(false);
            
        }
        else {

            FireBall.gameObject.SetActive(true);
            
        }
    }
}
