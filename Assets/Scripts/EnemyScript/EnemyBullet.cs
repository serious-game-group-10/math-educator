using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 10;
    private const float BULLET_SPEED = 1f;
    private Vector2 bulletDirection;
    private GameObject player;
    private Rigidbody2D enemyBullet;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            bulletDirection = player.transform.position;
        }
        if (enemyBullet == null)
        {
            enemyBullet = GetComponent<Rigidbody2D>();
        }

        Destroy(this, 3f);
    }

    void Update()
    {
        enemyBullet.velocity = bulletDirection * BULLET_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(BULLET_DAMAGE);
            Destroy(gameObject);
        }
    }
}