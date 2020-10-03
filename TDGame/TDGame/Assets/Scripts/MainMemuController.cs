using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMemuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
