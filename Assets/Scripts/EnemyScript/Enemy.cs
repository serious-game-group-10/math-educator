using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            DataPersistor.instance.addHighScore();
        }
        Destroy(this.gameObject);
    }
}
