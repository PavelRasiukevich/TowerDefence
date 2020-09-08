using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float gap = 10f;

    public float min, max;

    private Vector3 _movement;
    private Vector3 _currentposition;

    private void Start()
    {

    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        _currentposition = transform.position;
        _currentposition.y = Mathf.Clamp(_currentposition.y, min, max);
        transform.position = _currentposition;

        _movement = new Vector3(h, scroll, v);

        transform.Translate(_movement * cameraSpeed * Time.deltaTime, Space.World);

        if (Input.mousePosition.y > Screen.height - gap)
        {
            transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.y < gap)
        {
            transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x > Screen.width - gap)
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x < gap)
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime, Space.World);
        }



    }
}
