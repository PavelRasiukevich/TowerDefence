using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public int bounty;

    [HideInInspector]
    public float speed;

    public float startSpeed;

    private void Awake()
    {
        speed = startSpeed;
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();

    }

    private void Die()
    {
        AddBounty();
        Destroy(gameObject);
    }

    private void AddBounty()
    {
        PlayerStats.ammountOfMoney += bounty;
    }

    internal void Slow(float value)
    {
        speed = startSpeed * (1.0f - value);
    }
}
