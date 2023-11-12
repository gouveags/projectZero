using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float velObj;
    public bool goRight;
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

            transform.position = Vector2.MoveTowards(transform.position, b.position, velObj * Time.deltaTime);
        }
        else
        {

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;

            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, velObj * Time.deltaTime);
        }
    }
    
}
