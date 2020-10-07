using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text wavesMessage;

    private void OnEnable()
    {
        wavesMessage.text = PlayerStats.wavesSurvived.ToString();
    }

}
