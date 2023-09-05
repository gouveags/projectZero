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
    public int jumpForce;
    public int gravidadeScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = CheckpointController.currentCheckpoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        //when player die 

        if (GetComponent<Character>().life <= 0)
        {
            rb.gravityScale = gravidadeScale;
            this.enabled = false;
            rb.simulated = false;
            Invoke("LoadNextScene", deathDelay);
            
        }
       
        //Control Dash

        dashTime = dashTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(skin.localScale.x * 400,0));
            rb.gravityScale = 0;
        }
        if (dashTime > 0.3)
        {
            rb.gravityScale = gravidadeScale;
        }

        //Control combotime

        comboTime = comboTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboNum++;
            if (comboNum>2) {
                comboNum = 1;
            }
            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);  
        }
        if (comboTime >= 2)
        {
            comboNum = 0;  
        }

        //Sytem Jump

        bool canJump = Physics2D.OverlapCircle(floor.position, 0.1f, FloorLayer);
        if (canJump && Input.GetButtonDown("Jump"))
        {
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce ));
            rb.gravityScale = gravidadeScale;
        }
        

        vel = new Vector2(Input.GetAxisRaw("Horizontal")*5,rb.velocity.y);


        //Run and RunSword

        if (Input.GetAxisRaw("Horizontal") != 0 && comboNum == 0) {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }
        else { 
            skin.GetComponent<Animator>().SetBool("PlayerRun", false); 
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && comboNum >= 1)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skin.GetComponent<Animator>().SetBool("PlayerRunSword", true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRunSword", false);
        }

    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        if(dashTime > 0.3) {
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

}
