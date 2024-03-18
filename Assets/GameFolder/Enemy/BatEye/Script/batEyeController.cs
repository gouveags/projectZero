using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batEyeController : MonoBehaviour
{
    public int speed;
    GameObject Player;
    public float attackTime;
    public Transform skin;
    bool isStunned = false;
    float stunTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned)
        {
            stunTimer += Time.deltaTime;
            if (stunTimer >= 1f)
            {
                isStunned = false;
                stunTimer = 0f;
            }
            else
            {
                return; // Se estiver atordoado, não faça nada
            }
        }

        speed = Random.Range(3, 6);

        if (GetComponent<CharacterEnemmy>().life <= 0)
        {
            this.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 6;
            Destroy(gameObject, 1f);
        }

        Vector3 targetPosition = Player.GetComponent<CapsuleCollider2D>().bounds.center;
        Vector3 directionToPlayer = Player.transform.position - transform.position;
        directionToPlayer.y = 0; // Make sure the enemy only follows on the X-axis

        // Face the player's direction
        if (directionToPlayer.x > 0)
        {
            skin.localScale = new Vector3(1, 1, 1);
        }
        else if (directionToPlayer.x < 0)
        {
            skin.localScale = new Vector3(-1, 1, 1);
        }

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
                    skin.GetComponent<Animator>().Play("attack", -1);
                }
                else
                {
                    // Causar dano ao jogador
                    Player.GetComponent<Character>().PlayerDamage(Random.Range(1, 2));
                    skin.GetComponent<Animator>().Play("attack", -1);
                }

                isStunned = true; // Ativar o atordoamento
            }
        }
    }
}
