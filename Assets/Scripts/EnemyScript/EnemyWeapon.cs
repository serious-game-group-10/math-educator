using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] AudioSource fireBulletSound;

    private void Start()
    {
        fireBulletSound = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(fireBulletSound.clip, transform.position);
    }
}
