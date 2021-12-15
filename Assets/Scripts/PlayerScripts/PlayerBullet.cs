using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private const int BULLET_DAMAGE = 20;
    private const float BULLET_SPEED = 1f;
    private GameObject enemy;
    private Rigidbody2D playerBullet;

    void Start()
    {
        if(enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }

        playerBullet = gameObject.GetComponent<Rigidbody2D>();
        
        PlayerBuleltMovement();
        Destroy(this.gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.GetComponent<Enemy>().TakeDamage(BULLET_DAMAGE);
            Destroy(gameObject);
        }
    }

    private void PlayerBuleltMovement()
    {
        Vector2 force = (enemy.transform.position - transform.position).normalized * BULLET_SPEED;
        playerBullet.velocity = new Vector2(force.x, force.y);

        float rotationAngle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
        playerBullet.rotation = rotationAngle;
    }
}