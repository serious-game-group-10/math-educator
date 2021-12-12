using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 20;
    private const float BULLET_SPEED = 5f;
    private Enemy enemy;
    private Rigidbody2D playerBullet;
    private UIController uIController;

    void Start()
    {
        if(enemy == null)
        {
            enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        }

        if(uIController == null)
        {
            uIController = GameObject.Find("LevelController").GetComponent<UIController>();
        }

        playerBullet = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerBullet.velocity = enemy.transform.position * BULLET_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            enemy.GetComponent<Enemy>().TakeDamage(BULLET_DAMAGE);
            Destroy(gameObject);
        }
    }
}