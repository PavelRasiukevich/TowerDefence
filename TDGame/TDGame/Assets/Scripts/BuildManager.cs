using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject defaultTowerToBuild;
    private GameObject towerToBuild;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        towerToBuild = defaultTowerToBuild;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
