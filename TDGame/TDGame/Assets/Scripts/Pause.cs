using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject ui;

    public SceneFader sceneFader;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (GameController.GameIsOver)
        {
            return;
        }

        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
        Toggle();

    }

    public void MainMenu()
    {
        sceneFader.FadeTo(0);
        Toggle();
    }

}
