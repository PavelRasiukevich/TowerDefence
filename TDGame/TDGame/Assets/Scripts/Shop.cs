using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public TowerBlueprint blaster;
    public TowerBlueprint cannon;

    public GameObject blasterGhost;
    public GameObject cannonGhost;

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
}
