using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
   
    public Transform enemyRanger;
    
    public Transform lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GetComponent<CharacterEnemmy>().life <= 0)
        {
            enemyRanger.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            
            GetComponent<enemyController>().lifeBar.localScale = new Vector3(0, 1, 1);
        }

    }
    private void FixedUpdate()
    {
        lifeBar.localScale = new Vector3(GetComponent<CharacterEnemmy>().life / (float)GetComponent<CharacterEnemmy>().MaxLife, 1, 1);
    }
}
