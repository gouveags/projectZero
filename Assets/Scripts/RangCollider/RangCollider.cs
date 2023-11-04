using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangCollider : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            transform.parent.GetComponent<Animator>().Play("Attack", -1);

        }
    }
}
