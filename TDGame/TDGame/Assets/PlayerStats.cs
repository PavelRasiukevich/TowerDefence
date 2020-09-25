using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int ammountOfMoney;
    public int startMoney;

    public static int lives;
    public int startLives;

    public static int wavesSurvived;


    private void Awake()
    {
        wavesSurvived = 0;
        ammountOfMoney = startMoney;
        lives = startLives;
    }
}
