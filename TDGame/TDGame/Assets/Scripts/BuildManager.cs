using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public Text money;

    private TowerBlueprint _towerToBuild;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        money.text = string.Format("${0}", PlayerStats.ammountOfMoney);
    }

    public bool canBuild { get { return _towerToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.ammountOfMoney >= _towerToBuild.price; } }

    public void SetTowerToBuild(TowerBlueprint blueprint)
    {
        _towerToBuild = blueprint;
    }

    public void BuildTowerOn(Tile tile)
    {
        if (PlayerStats.ammountOfMoney < _towerToBuild.price)
        {
            Debug.Log("Not enough money!");
            return;
        }


        GameObject tower = Instantiate(_towerToBuild.prefab, tile.GetPositionToBuild(), Quaternion.identity);
        tile.tower = tower;

        PlayerStats.ammountOfMoney -= _towerToBuild.price;
        money.text = string.Format("${0}", PlayerStats.ammountOfMoney);

    }
}
