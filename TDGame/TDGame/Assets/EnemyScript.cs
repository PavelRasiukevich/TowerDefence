using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float startHealth;
    public float health;
    public int bounty;

    public string enemyName;

    public Image hpBar;

    [HideInInspector]
    public float speed;

    public float startSpeed;

    private void Awake()
    {
        health = startHealth;
        speed = startSpeed;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
       //Debug.LogWarning(health);
        hpBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
            return;
        }

    }

    public void Die()
    {
        AddBounty();
        Destroy(gameObject);
        //Debug.LogWarning(gameObject.name + " destroyed");
        GameManager.instance.EnemiesAlive--;
        //Debug.LogWarning("EnemiesAlive decreased");
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
