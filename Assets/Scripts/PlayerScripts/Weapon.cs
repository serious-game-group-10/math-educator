using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab1;
    [SerializeField] GameObject bulletPrefab2;
    [SerializeField] GameObject bulletPrefab3;
    [SerializeField] GameObject bulletPrefab4;

    //Attack Style One
    public void ShootOne()
    {
        Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
    }

    //Attack Style Two
    public void ShootTwo()
    {
        Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
    }

    //Attack Style Three
    public void ShootThree()
    {
        Instantiate(bulletPrefab3, firePoint.position, firePoint.rotation);
    }

    //Attack Style Four
    public void ShootFour()
    {
        Instantiate(bulletPrefab4, firePoint.position, firePoint.rotation);
    }
}
