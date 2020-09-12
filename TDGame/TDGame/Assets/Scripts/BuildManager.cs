using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("List of towers to build")]
    public GameObject blaster;
    public GameObject cannon;


    private GameObject _towerToBuild;

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        _towerToBuild = tower;
    }
}
