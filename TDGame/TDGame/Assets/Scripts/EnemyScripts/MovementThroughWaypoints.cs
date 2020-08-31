using UnityEngine;

public class MovementThroughWaypoints : MonoBehaviour
{
    public float speed;
    public Transform target;
    private int index;

    private void Start()
    {
        target = WaypointCollector.points[0];
    }

    private void Update()
    {
        Vector3 destination = target.position - transform.position;

        transform.Translate(destination.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position,target.position) <= 0.2f)
        {
            SetNewDestinationPoint();
        }
    }

    private void SetNewDestinationPoint()
    {
        if (index >= WaypointCollector.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        index++;
        target = WaypointCollector.points[index];
    }
}
