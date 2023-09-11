using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using CoreMechanics;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    public Transform floor;
    public LayerMask FloorLayer;
    public Transform skin;
    public int comboNum;
    public float comboTime;
    public float dashTime;
    public float deathDelay = 2.0f;
    public float jumpForce;
    public int gravidadeScale;
    public AudioSource audioSouce;
    public AudioClip groundedSound;

    public bool isGrounded;
    public bool isJumping; // Variável de controle de salto
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = skin.GetComponent<Animator>();
        transform.position = CheckpointController.currentCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGrounded", isGrounded);
       

        // Quando o jogador morre
        if (GetComponent<Character>().life <= 0)
        {
            rb.gravityScale = gravidadeScale;
            this.enabled = false;
            rb.simulated = false;
            Invoke("LoadNextScene", deathDelay);
        }

        // Controlando o Dash
        dashTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(skin.localScale.x * 400, 0));
            rb.gravityScale = 0;
        }
        if (dashTime > 0.3)
        {
            rb.gravityScale = gravidadeScale;
        }

        // Controlando o comboTime
        comboTime += Time.deltaTime;
        if ((Input.GetButtonDown("Fire1") && comboTime > 0.5f) || (isJumping && Input.GetButtonDown("Fire1"))) // Verificando "Fire1" no ar
        {
            comboNum++;

            if (comboNum > 2)
            {
                comboNum = 1;
            }
            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);
            audioSouce.PlayOneShot(groundedSound, 0.05f);
        }
        if (comboTime >= 2)
        {
            comboNum = 0;
        }

        // Sistema de pulo
        isGrounded = Physics2D.OverlapCircle(floor.position, 0.05f, FloorLayer);

        // Verifica se o jogador está no chão e permite o pulo
        if (isGrounded)
        {
            isJumping = false;
        }

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 5, rb.velocity.y);

        // Correndo e Atacando Correndo
        if (Input.GetAxisRaw("Horizontal") != 0 && comboNum == 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("PlayerRun", true);
        }
        else
        {
            animator.SetBool("PlayerRun", false);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && comboNum >= 1)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("PlayerRunSword", true);
        }
        else
        {
            animator.SetBool("PlayerRunSword", false);
        }

        // Continuar a animação de salto enquanto estiver no ar
        if (!isGrounded && rb.velocity.y > 0)
        {
            animator.Play("PlayerJump", -1);
            isJumping = true;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        if (dashTime > 0.3)
        {
            rb.velocity = vel;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Plataform"))
            this.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Plataform"))
            this.transform.parent = null;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        rb.gravityScale = gravidadeScale;
        animator.Play("PlayerJump", -1);
        isGrounded = false;
        isJumping = true; // Define como verdadeira quando o jogador pula
    }
}
