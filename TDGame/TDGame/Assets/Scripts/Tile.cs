using UnityEngine;

public class Tile : MonoBehaviour
{

    public GameObject tower;
    public Vector3 positionOffset;

    private Renderer _tileRenderer;
    private Color _defaultColor;
    private Material[] _materials;

    private void Start()
    {
        _tileRenderer = GetComponent<Renderer>();

        _materials = _tileRenderer.materials;

        _defaultColor = _materials[1].color;
    }

    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Impossible to build.");
            return;
        }

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();

        tower = Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if(tower == null)
        {
            _materials[1].color = Color.green;
        }
        else
        {
            _materials[1].color = Color.red;
        }

        
    }

    private void OnMouseExit()
    {
        _materials[1].color = _defaultColor;
    }
}
