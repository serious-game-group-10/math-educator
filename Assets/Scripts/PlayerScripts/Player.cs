using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.5f;
    [SerializeField] float movement;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] Animator anim;
    const int idle = 0;
    const int moving = 1;
    [SerializeField] Rigidbody2D playerBody;
    
    [SerializeField] int health;

    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

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
            speed = 1.5f;
        }
        else
        {
            movement = 0f;
            speed = 0f;
        }
    }

    private void FixedUpdate()
    {
        Movement();
        //changing state if moving or not
        if (movement != 0)
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

    public void TakeDamage(int damagePoint)
    {
        health -= damagePoint;
        this.gameObject.GetComponent<PlayerHealth>().UpdateHealth(health);

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
