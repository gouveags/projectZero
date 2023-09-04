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
            GetComponent<Rigidbody2D>().gravityScale = 6;
        }


        if (Vector2.Distance(transform.position, Player.GetComponent<CapsuleCollider2D>().bounds.center)>0.5f) {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, Player.GetComponent<CapsuleCollider2D>().bounds.center, 3.0f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;
            if (attackTime >= 0.3f)
            {
                attackTime = 0;
                Player.GetComponent<Character>().PlayerDamege(Random.Range(1, 2));
            }
        }
        
    }
}
