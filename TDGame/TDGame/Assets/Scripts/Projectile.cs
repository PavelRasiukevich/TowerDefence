using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed;
    public GameObject impactEffect;
    public float distanceThisFrame;

    public void Seek(Transform _target)
    {
        target = _target;
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
    }

    private void HitTarget()
    {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 0.35f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
