using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void PurchaseBlaster()
    {
        _buildManager.SetTowerToBuild(_buildManager.blaster);

    }

    public void PurchaseCannon()
    {
        _buildManager.SetTowerToBuild(_buildManager.cannon);
    }
}
