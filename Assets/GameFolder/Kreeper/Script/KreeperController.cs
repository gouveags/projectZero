using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public Transform Skin;

    public bool goRight;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(goRight == true)
        {
            Skin.localScale = new Vector3(1, 1, 1);
            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, b.position, 0.2f * Time.deltaTime);
        }
        else
        {
            Skin.localScale = new Vector3(-1, 1, 1);
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, 0.2f * Time.deltaTime);
        }
    }
}
