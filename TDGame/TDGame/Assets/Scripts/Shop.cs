using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public TowerBlueprint blaster;
    public TowerBlueprint cannon;
    public TowerBlueprint laser;
    public TowerBlueprint arrow;


    [Header("Ghost Buildings")]
    public GameObject blasterGhost;
    public GameObject cannonGhost;
    public GameObject laserGhost;
    public GameObject arrowGhost;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void SelectBlaster()
    {
        Tile.ghostPrefab = blasterGhost;
        _buildManager.SetTowerToBuild(blaster);
    }

    public void SelectCannon()
    {
        Tile.ghostPrefab = cannonGhost;
        _buildManager.SetTowerToBuild(cannon);
    }

    public void SelectLaser()
    {
        Tile.ghostPrefab = laserGhost;
        _buildManager.SetTowerToBuild(laser);
    }

    public void SelectArrow()
    {
        Tile.ghostPrefab = arrowGhost;
        _buildManager.SetTowerToBuild(arrow);
    }


}
