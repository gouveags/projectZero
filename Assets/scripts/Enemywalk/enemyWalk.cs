using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWalk : MonoBehaviour
{
    GameObject Player;
    public Transform Skin;
    int speed;
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        life = GetComponent<CharacterEnemmy>().life;
        speed = Random.Range(2, 3);

        
        if (life <=0)
        {
            this.enabled = false;
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
        targetPosition.y = transform.position.y; // Mant�m a mesma altura do inimigo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
