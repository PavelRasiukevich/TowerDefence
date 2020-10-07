using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Material[] meshRenderer;
    private float timer;
    private void Start()
    {
        timer = 1f;
        meshRenderer = GetComponent<MeshRenderer>().materials;
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            meshRenderer[0].color = new Color(Random.value, Random.value, Random.value);
            timer = 0.5f;
        }
        

        transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
    }
}
