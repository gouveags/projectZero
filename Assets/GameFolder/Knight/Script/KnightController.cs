using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float velKnight;
    public Transform Skin;
    public Transform KnightRange;
    public bool goRight;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            KnightRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }


        if (Skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KnightAttack"))
        {
            return;
        }


        if (goRight == true)
        {
            Skin.localScale = new Vector3(1, 1, 1);
            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;

            }

            transform.position = Vector2.MoveTowards(transform.position, b.position, velKnight * Time.deltaTime);
        }
        else
        {
            Skin.localScale = new Vector3(-1, 1, 1);
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;

            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, velKnight * Time.deltaTime);
        }



    }
}
