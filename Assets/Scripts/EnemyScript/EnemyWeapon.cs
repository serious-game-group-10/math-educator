using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform dropPoint;
    public GameObject bulletPrefab;
    [SerializeField] AudioSource fireBulletSound;
    private int repeatTimes = 0;

    private void Start()
    {
        if (fireBulletSound == null)
        {
            fireBulletSound = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        fireBulletSound.volume = DataPersistor.instance.getGameVolume();
    }

    private void Shoot(Transform shootPoint)
    {
        Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        fireBulletSound.Play();
    }

    public void GenericAttack()
    {
        Shoot(firePoint);
    }

    public void RobotAttack()
    {
        InvokeRepeating("RobotMissleAttack", 0.3f, 0.6f);
        repeatTimes = 0;
    }

    private void RobotMissleAttack()
    {
        Shoot(dropPoint);
        repeatTimes++;
        if (repeatTimes == 5)
        {
            CancelInvoke();
        }
    }
}
