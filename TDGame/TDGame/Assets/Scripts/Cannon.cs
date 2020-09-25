using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform partToRotate;
    public Transform firePoint;
    public ParticleSystem laserGlow;

    public GameObject arrow;

    public bool isArrowTower;

    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountDown = 1f;
    public float range = 10f;
    public float turnSpeed = 10f;

    [Header("Laser")]
    public bool laserOn = false;
    public LineRenderer lineRenderer;
    public int laserDamage;
    public float laserDamageRate;
    private float laserCountDown;

    public float slowValue = 0.5f;

    private string enemyTag = "Enemy";
    private Transform target = null;
    private EnemyScript targetEnemy;




    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0, 0.5f);

    }
    
    private void Awake()
    {
        Projectile.ArrowDestroyed += ArrowDestroyedHandler;
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
                targetEnemy = nearesEnemy.GetComponent<EnemyScript>();
            }
            else
            {
                target = null;
            }
        }
    }


    private void Update()
    {
        if (target == null)
        {
            if (laserOn)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserGlow.Stop();
                }
            }
            return;
        }


        if (laserOn)
        {
            Laser();
        }
        else
        {
            if (target != null)
            {
                if (fireCountDown <= 0)
                {
                    if (isArrowTower)
                        arrow.SetActive(false);

                    Shoot();
                    fireCountDown = 1f / fireRate;
                }

            }

            fireCountDown -= Time.deltaTime;
        }

        LockOnTarget();
    }

    private void Laser()
    {

        #region Laser Glow 
        laserGlow.Play();

        Vector3 dir = firePoint.transform.position - target.position;
        laserGlow.transform.position = target.position + dir.normalized * 0.25f;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(1, firePoint.position);
        lineRenderer.SetPosition(0, target.position);
        #endregion

        #region Damage 
        if (laserCountDown <= 0)
        {
            targetEnemy.TakeDamage(laserDamage);
            laserCountDown = 1f / laserDamageRate;
        }

        laserCountDown -= Time.deltaTime;
        #endregion

        #region Slow
        //targetEnemy.Slow(true);
        targetEnemy.Slow(slowValue);
        #endregion
    }

    void LockOnTarget()
    {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void ArrowDestroyedHandler()
    {
        if (isArrowTower)
            arrow.SetActive(true);
    }
}
