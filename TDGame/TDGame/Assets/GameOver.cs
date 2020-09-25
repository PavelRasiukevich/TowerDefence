using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text wavesMessage;

    private void OnEnable()
    {
        wavesMessage.text = PlayerStats.wavesSurvived.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Menu()
    {

    }
}
