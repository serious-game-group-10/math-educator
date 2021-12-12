using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    //Attack Style One
    public void ShootOne()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Attack Style Two
    public void ShootTwo()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Attack Style Three
    public void ShootThree()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Attack Style Four
    public void ShootFour()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
