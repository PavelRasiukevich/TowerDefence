using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text m;

    private void Update()
    {
        m.text = string.Format("${0}", PlayerStats.ammountOfMoney);
    }
}
