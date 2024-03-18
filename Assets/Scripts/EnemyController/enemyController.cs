using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    int speed;
    public Transform Skin;
    public Transform enemyRanger;
    GameObject Player;
    public Transform lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(3, 6);

        if (GetComponent<CharacterEnemmy>().life <= 0)
        {
            enemyRanger.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            GetComponent<enemyController>().lifeBar.localScale = new Vector3(0, 1, 1);
        }

        if (Skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }


        // Calculate the direction vector from the enemy to the player
        Vector3 directionToPlayer = Player.transform.position - transform.position;
        directionToPlayer.y = 0; // Make sure the enemy only follows on the X-axis

        // Face the player's direction
        if (directionToPlayer.x > 0)
        {
            Skin.localScale = new Vector3(1, 1, 1);
        }
        else if (directionToPlayer.x < 0)
        {
            Skin.localScale = new Vector3(-1, 1, 1);
        }


        // Move towards the player on the X-axis
        float step = speed * Time.deltaTime;
        Vector3 targetPosition = Player.transform.position;
        targetPosition.y = transform.position.y; // Mantém a mesma altura do inimigo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);


    }
    private void FixedUpdate()
    {
        lifeBar.localScale = new Vector3(GetComponent<CharacterEnemmy>().life / (float)GetComponent<CharacterEnemmy>().MaxLife, 1, 1);
    }
}
