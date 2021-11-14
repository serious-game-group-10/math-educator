using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
