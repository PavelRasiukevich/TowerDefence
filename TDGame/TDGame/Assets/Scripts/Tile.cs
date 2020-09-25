using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public GameObject tower;
    public TowerBlueprint towerBlueprint;
    public bool isUpgraded = false;

    private BuildManager _buildManager;
    public Vector3 positionOffset;

    private Renderer _tileRenderer;
    private Color _defaultColor;
    private Material[] _materials;

    public static GameObject ghostPrefab;
    private GameObject _ghost;

    private void Start()
    {
        _buildManager = BuildManager.instance;

        _tileRenderer = GetComponent<Renderer>();

        _materials = _tileRenderer.materials;

        _defaultColor = _materials[1].color;

        GameManager.instance.secondMouseButtonClick += secondMouseButtonClickHandler;
    }

    public Vector3 GetPositionToBuild()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (tower != null)
        {
            _buildManager.SelectTile(this);
            return;
        }


        if (!_buildManager.canBuild)
            return;


        //_buildManager.BuildTowerOn(this);
        BuildTower(_buildManager.GetTowerToBuild());

    }

    public void BuildTower(TowerBlueprint blueprintTower)
    {
        if (PlayerStats.ammountOfMoney < blueprintTower.price)
        {
            Debug.Log("Not enough money!");
            return;
        }


        GameObject _tower = Instantiate(blueprintTower.prefab, GetPositionToBuild(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprintTower;

        PlayerStats.ammountOfMoney -= blueprintTower.price;
    }

    public void UpgradeTower()
    {

        if (PlayerStats.ammountOfMoney < towerBlueprint.upgradePrice)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.ammountOfMoney -= towerBlueprint.price;

        Destroy(tower);

        GameObject _tower = Instantiate(towerBlueprint.upgradePrefab, GetPositionToBuild(), Quaternion.identity);
        tower = _tower;

        isUpgraded = true;

    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.canBuild)
            return;

        if (tower == null)
        {
            if (ghostPrefab != null)
                _ghost = Instantiate(ghostPrefab, GetPositionToBuild(), Quaternion.identity);

            if (_buildManager.hasMoney)
            {
                _materials[1].color = Color.green;
            }
            else
            {
                _materials[1].color = Color.red;
            }

        }
        else
        {
            _materials[1].color = Color.red;
        }

    }

    private void OnMouseExit()
    {
        DestroyGhostTower();

        _materials[1].color = _defaultColor;
    }

    private void OnMouseOver()
    {
        if (tower != null)
        {
            DestroyGhostTower();
        }
    }

    private void secondMouseButtonClickHandler()
    {
        BuildManager.instance.SetTowerToBuild(null);
        ghostPrefab = null;
        DestroyGhostTower();
        _materials[1].color = _defaultColor;
    }

    private void DestroyGhostTower()
    {
        if (_ghost != null)
        {
            Destroy(_ghost.gameObject);
        }
    }
}
