using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private int health;
    private Animator anim;
    [SerializeField] AudioSource explosionSound;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        if(enemyHealth == null)
        {
            enemyHealth = GetComponent<EnemyHealth>();
        }
        health = 100;
    }

    public void TakeDamage(int damagePoint)
    {
        health -= damagePoint;
        enemyHealth.updateHealth(health);

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }



}
