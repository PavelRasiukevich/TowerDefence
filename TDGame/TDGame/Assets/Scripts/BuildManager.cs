using System;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TowerBlueprint _towerToBuild;

    private Tile _selectedTile;

    public NodeUI nodeUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }

    public bool canBuild { get { return _towerToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.ammountOfMoney >= _towerToBuild.price; } }

    public void SelectTile(Tile tile)
    {
        if (_selectedTile == tile)
        {
            DeselectTile();
            return;
        }

        _selectedTile = tile;
        _towerToBuild = null;
        nodeUI.SetTarget(_selectedTile);
    }

    public void DeselectTile()
    {
        _selectedTile = null;
        nodeUI.Hide();
    }

    public void SetTowerToBuild(TowerBlueprint blueprint)
    {
        _towerToBuild = blueprint;
        DeselectTile();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return _towerToBuild;
    }
}
