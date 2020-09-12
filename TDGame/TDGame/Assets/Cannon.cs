using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform partToRotate;
    public Transform firePoint;

    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountDown = 1f;
    public float range = 10f;
    public float turnSpeed = 10f;

    private string enemyTag = "Enemy";
    private Transform target = null;




    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);
        
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
        if (target != null)
        {
            if (fireCountDown <= 0)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
        }


        fireCountDown -= Time.deltaTime;

        #region ROTATION
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
        #endregion
    }

    private void Shoot()
    {
        GameObject cannonBall = Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
        Projectile projectile = cannonBall.GetComponent<Projectile>();

        if (cannonBall != null)
        {
            projectile.Seek(target);
        }
    }
}
