using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static event Action ArrowDestroyed;

    public float explosionRadius = 0f;
    private Transform target;
    public float speed;
    public int damage;
    public GameObject impactEffect;
    public float distanceThisFrame;
    public Vector3 currentEnemyPosition;
    public LayerMask enemyMask;


    [Header("Test")]
    public Collider[] colliders;

    public void Seek(Transform _target)
    {
        target = _target;
        currentEnemyPosition = target.position - transform.position;
    }

    private void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;

        }

        Vector3 direction = target.position - transform.position;

        distanceThisFrame = speed * Time.deltaTime;//distance grows up every frame

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void HitTarget()
    {

        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 0.35f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        
        Destroy(gameObject);

        ArrowDestroyed?.Invoke();

    }



    private void Explode()
    {
        colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyMask);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);

            }
        }
    }

    private void Damage(Transform enemy)
    {
        enemy.GetComponent<EnemyScript>().TakeDamage(damage);
    }

}
