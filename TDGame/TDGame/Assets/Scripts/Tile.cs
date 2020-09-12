using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{

    public GameObject tower;
    private GameObject _towerToBuild;
    private BuildManager _buildManager;
    public Vector3 positionOffset;

    private Renderer _tileRenderer;
    private Color _defaultColor;
    private Material[] _materials;

    private void Start()
    {
        _buildManager = BuildManager.instance;

        _tileRenderer = GetComponent<Renderer>();

        _materials = _tileRenderer.materials;

        _defaultColor = _materials[1].color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (tower != null)
        {
            Debug.Log("Impossible to build.");
            return;
        }

        _towerToBuild = _buildManager.GetTowerToBuild();

        if (_towerToBuild != null)
            tower = Instantiate(_towerToBuild, transform.position + positionOffset, transform.rotation);

        BuildManager.instance.SetTowerToBuild(null);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (_buildManager.GetTowerToBuild() == null)
            return;

        if (tower == null)
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
