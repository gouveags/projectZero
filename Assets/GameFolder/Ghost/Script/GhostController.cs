using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
 
    public Transform Skin;
    public float velGhot;
    public bool goRight;
    GameObject Player;
    public Transform lifeBar;
    public float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 6;
            Destroy(gameObject, 1f);
            GetComponent<GhostController>().lifeBar.localScale = new Vector3(0, 1, 1);
        }

        // Calculate the direction vector from the enemy to the player
        Vector3 directionToPlayer = Player.transform.position - transform.position;
      

        // Face the player's direction
        if (directionToPlayer.x > 0)
        {
            Skin.localScale = new Vector3(-1, 1, 1);
        }
        else if (directionToPlayer.x < 0)
        {
            Skin.localScale = new Vector3(1, 1, 1);
        }

        // Move towards the player on the X-axis
      
        Vector3 targetPosition = Player.GetComponent<CapsuleCollider2D>().bounds.center;

        if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
        {
            attackTime = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 3.0f * Time.deltaTime);
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

    private void FixedUpdate()
    {
        lifeBar.localScale = new Vector3(GetComponent<Character>().life / 10f, 1, 1);
    }
    // Start is called before the first frame update


}
