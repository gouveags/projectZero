using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    public Transform Player;

    public float attackTime;


    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }


        if (Vector2.Distance(transform.position, Player.position)>1f) {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, 3.0f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;
            if (attackTime >= 0.2f)
            {
                attackTime = 0;
                Player.GetComponent<Character>().life--;
            }
        }
        
    }
}
