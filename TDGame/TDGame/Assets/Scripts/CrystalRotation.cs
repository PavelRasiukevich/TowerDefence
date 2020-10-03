using UnityEngine;

public class CrystalRotation : MonoBehaviour
{
    private float speed;
    private int direction;

    private void Start()
    {
        speed = Random.Range(0.5f, 1.5f);
        direction = Random.Range(-1, 2);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed );
    }
}
