using System;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountDown = 1f;
    public float range = 10f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;

    private Transform target;

    public GameObject projectilePrefab;
    public Transform firePointRigth;
    public Transform firePointLeft;



    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearesEnemy = enemy;
            }

            if (nearesEnemy != null && shortestDistance <= range)
            {
                target = nearesEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }


    private void Update()
    {

        if (fireCountDown <= 0)
        {
            Shoot();

            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;

        if (target == null)
        {
            //partToRotate.rotation = Quaternion.identity;
            return;
        }
        else
        {
            Vector3 direction = target.position - transform.position;//define a pointer in which direction to look
            Quaternion lookRotation = Quaternion.LookRotation(direction);//create a rotation using specific direction
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //convert from quaternions to eulers angles
            partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);
        }

        

    }

    private void Shoot()
    {
        GameObject bulletRight = Instantiate(projectilePrefab, firePointRigth.position, projectilePrefab.transform.rotation);
        GameObject bulletLeft = Instantiate(projectilePrefab, firePointLeft.position, projectilePrefab.transform.rotation);

        Projectile projectile_1 = bulletRight.GetComponent<Projectile>();
        Projectile projectile_2 = bulletLeft.GetComponent<Projectile>();

        if (projectile_1 != null && projectile_2 != null)
        {
            projectile_1.Seek(target);
            projectile_2.Seek(target);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
