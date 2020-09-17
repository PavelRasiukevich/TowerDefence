using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int ammountOfMoney;
     
    public int startMoney = 75;

    private void Awake()
    {
        ammountOfMoney = startMoney;
    }
}
