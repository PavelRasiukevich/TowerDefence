using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class MovementThroughWaypoints : MonoBehaviour
{

    public Transform target;
    private int index;

    private EnemyScript enemy;

    private void Start()
    {
        target = WaypointCollector.points[0];
        enemy = GetComponent<EnemyScript>();
    }

    private void Update()
    {
        Vector3 destination = target.position - transform.position;

        transform.Translate(destination.normalized * enemy.speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            SetNewDestinationPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void SetNewDestinationPoint()
    {
        if (index >= WaypointCollector.points.Length - 1)
        {
            ActionAfterReachTheLastPoint();
            return;
        }

        index++;
        target = WaypointCollector.points[index];
    }

    private void ActionAfterReachTheLastPoint()
    {
        switch (enemy.enemyName)
        {
            case "Regular":
                PlayerStats.lives -= 3;
                break;
            case "Slim":
                PlayerStats.lives -= 4;
                break;
            case "Fat":
                PlayerStats.lives -= 5;
                break;
            case "Giga":
                PlayerStats.lives -= 10;
                break;
            default:
                PlayerStats.lives--;
                break;

        }

        GameManager.instance.EnemiesAlive--;
        Destroy(gameObject);
    }
}
