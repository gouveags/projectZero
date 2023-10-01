using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform Skin;
    public int speed;
    public bool goRight;
    GameObject Player;
    public Transform lifeBar;
    public float attackTime;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        speed = Random.Range(3, 6);

        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 6;
            Destroy(gameObject, 1f);
            GetComponent<GhostController>().lifeBar.localScale = new Vector3(0, 1, 1);
        }

        Vector3 directionToPlayer = Player.transform.position - transform.position;

        if (directionToPlayer.x > 0)
        {
            Skin.localScale = new Vector3(-1, 1, 1);
        }
        else if (directionToPlayer.x < 0)
        {
            Skin.localScale = new Vector3(1, 1, 1);
        }

        Vector3 targetPosition = Player.GetComponent<CapsuleCollider2D>().bounds.center;

        if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
        {
            attackTime = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;
            if (attackTime >= 0.3f)
            {
                attackTime = 0;

                // Verificar se o escudo do jogador está ativo
                bool shieldActive = Player.GetComponent<Character>().shieldActive;

                if (shieldActive)
                {
                    // Causar dano ao escudo
                    Player.GetComponent<Character>().ShieldDamage(Random.Range(1, 2));
                    
                }
                else
                {
                    // Causar dano ao jogador
                    Player.GetComponent<Character>().PlayerDamage(Random.Range(1, 2));
                }
            }
        }
    }

    void FixedUpdate()
    {
        lifeBar.localScale = new Vector3(GetComponent<Character>().life / 10f, 1, 1);
    }
}
