using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 30f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(removeBullet());
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Enemy enemy = collision.GetComponent<Enemy>();

    //     if (enemy != null)
    //     {
    //         enemy.takeDamage(20);
    //         Destroy(gameObject);
    //     }
    // }

    IEnumerator removeBullet()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}