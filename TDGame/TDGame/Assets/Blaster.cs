using UnityEngine;

public class Blaster : MonoBehaviour
{
    private Transform target;
    public float range = 10f;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;

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
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;//define a pointer in which direction to look
            Quaternion lookRotation = Quaternion.LookRotation(direction);//create a rotation using specific direction
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //convert from quaternions to eulers angles
            partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);
        }


        if (target == null)
        {
            //partToRotate.rotation = Quaternion.identity;
            return;
        }
            

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
