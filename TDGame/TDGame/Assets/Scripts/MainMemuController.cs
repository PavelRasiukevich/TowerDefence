using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMemuController : MonoBehaviour
{
    public SceneFader sceneFader;

    public void StartGame(int index)
    {
        sceneFader.FadeTo(index);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
