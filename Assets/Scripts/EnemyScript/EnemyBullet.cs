using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 10;
    private const float BULLET_SPEED = 3f;
    private GameObject player;
    private Rigidbody2D enemyBullet;

    void Start()
    {
        player = GameObject.Find("Player");
        if (enemyBullet == null)
        {
            enemyBullet = GetComponent<Rigidbody2D>();
        }

        EnemyBulletMovement();
        Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(BULLET_DAMAGE);
            Destroy(gameObject);
        }
    }

    private void EnemyBulletMovement()
    {
        Vector2 force = (player.transform.position - transform.position).normalized * BULLET_SPEED;
        enemyBullet.velocity = new Vector2(force.x, force.y);

        float rotationAngle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
        enemyBullet.rotation = rotationAngle;
    }
}