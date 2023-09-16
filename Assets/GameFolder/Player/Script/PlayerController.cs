using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CoreMechanics;

public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private int life;
        private Vector2 vel;
        public Transform floor;
        public LayerMask FloorLayer;
        public Transform skin;
        public int comboNum;
        public float comboTime;
        public float dashTime;
        public float deathDelay;
        public float jumpForce;
        public int gravidadeScale;
        public AudioSource audioSource;
        public AudioClip groundedSound;
        private GameObject objetoParaMudarTag;
        public bool isGrounded;
        public bool isJumping;
        private Animator animator;
        public int coin = 0;
        public Text CoinCountText;
        public Text heartCountText;
        public Transform Heart;



    void Start()
        {
            life = GetComponent<Character>().life;
            rb = GetComponent<Rigidbody2D>();
            animator = skin.GetComponent<Animator>();
            transform.position = CheckpointController.currentCheckpoint;
            objetoParaMudarTag = GameObject.Find("Player");
        }

        void Update()
        {

        heartCountText.text = "x" + GetComponent<Character>().life.ToString();
       
        animator.SetBool("isGrounded", isGrounded);

        if (life <= 5 && life >= 1)
        {
            Heart.GetComponent<Animator>().Play("HeartWarning", -1);
            
        }
        else if (life <= 0 )
        {

            Destroy(gameObject, 2f);
            animator.GetComponent<Animator>().Play("Die", -1);
            Heart.GetComponent<Animator>().Play("HeartDead", -1);
            life = 0;

        }
        if (GetComponent<Character>().life <= 0)
            {
                rb.gravityScale = gravidadeScale;
                this.enabled = false;
                rb.simulated = false;
            
               Invoke("LoadNextScene", deathDelay);
            }

            dashTime += Time.deltaTime;
            if (Input.GetButtonDown("Fire2") && dashTime > 1)
            {
                objetoParaMudarTag.tag = "Imune";
                dashTime = 0;
                skin.GetComponent<Animator>().Play("PlayerDash", -1);
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(skin.localScale.x * 400, 0));
                rb.gravityScale = 0;
            }
            if (dashTime > 0.3f)
            {
                rb.gravityScale = gravidadeScale;
                objetoParaMudarTag.tag = "Player";
            }

            comboTime += Time.deltaTime;
            if ((Input.GetButtonDown("Fire1") && comboTime > 0.5f) || (isJumping && Input.GetButtonDown("Fire1") && comboTime > 0.5f))
            {
                comboNum++;
                if (comboNum > 2)
                {
                    comboNum = 1;
                }
                comboTime = 0;
                skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);
                audioSource.PlayOneShot(groundedSound, 0.05f);
            }
            if (comboTime >= 2)
            {
                comboNum = 0;
            }

            isGrounded = Physics2D.OverlapCircle(floor.position, 0.05f, FloorLayer);

            if (isGrounded)
            {
                isJumping = false;
            }

            if (!isJumping && Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            vel = new Vector2(Input.GetAxisRaw("Horizontal") * 5, rb.velocity.y);

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

            if (!isGrounded && rb.velocity.y > 0)
            {
                animator.Play("PlayerJump", -1);
                isJumping = true;
            }

        CoinCountText.text = coin.ToString();
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
            isJumping = true;
        }
    }

