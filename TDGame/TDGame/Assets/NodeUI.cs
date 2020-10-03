using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Tile target;
    public GameObject ui;

    public Text upgradePrice;
    public Text sellPrice;

    public Button upgradeButton;

    public void SetTarget(Tile _target)
    {


        if (_target.isUpgraded == false)
        {
            upgradePrice.text = string.Format("${0}", _target.towerBlueprint.upgradePrice);
            upgradeButton.interactable = true;
        }
        else
        {
            upgradePrice.text = string.Format("{0}", "Done!");
            upgradeButton.interactable = false;
        }


        sellPrice.text = string.Format("${0}", _target.towerBlueprint.price / 2);


        ui.SetActive(true);
        target = _target;
        transform.position = target.GetPositionToBuild();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectTile();
    }

    public void SellTower()
    {
        target.Sell();
        BuildManager.instance.DeselectTile();
    }
}
