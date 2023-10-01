using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private Animator animator;
    public Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Character character = Player.GetComponent<Character>();

        // Verifica o valor de shieldActive no Character.
        bool shieldActive = character.shieldActive;

        // Define o parâmetro "shieldOn" no Animator com base no valor de shieldActive.
        animator.SetBool("ShieldOn", shieldActive);
    }
}
