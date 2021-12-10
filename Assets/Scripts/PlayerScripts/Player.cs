using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float movement;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] Rigidbody2D playerBody;
    
    [SerializeField] Text healthText;
    [SerializeField] int health = 5;
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] Animator anim;
    const int idle = 0;
    const int moving = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (anim == null){
            anim = GetComponent<Animator>();
        }
       
        if (playerBody == null)
        {
            playerBody = GetComponent<Rigidbody2D>();
        }
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(!DataPersistor.instance.getInFight())
        {
            movement = Input.GetAxis("Horizontal");
        }
        else
        {
            speed = 0f;
        }
    }

    private void FixedUpdate()
    {
        Movement();
        //changing state if moving or not
        if (movement > .01 || movement < -.01)
            {
                anim.SetInteger("motion", moving);
            }
        else
            {
                anim.SetInteger("motion", idle);
            }
        
        // check if facing right direction
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    private void Movement()
    {
        playerBody.velocity = new Vector2(movement * speed, playerBody.velocity.y);
    }

    private void Flip()
    {
        this.transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        //playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
        //playerBody.AddForce(new Vector2(0, jumpPower * 30.0f));
        //isGrounded = false;
        //jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    public void TakeDamage(int damagePoint)
    {
        health -= damagePoint;
        Debug.Log(health);
        this.gameObject.GetComponent<PlayerHealth>().UpdateHealth(health);
        Debug.Log(this.gameObject.GetComponent<PlayerHealth>());

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("EndScene");
    }
}
