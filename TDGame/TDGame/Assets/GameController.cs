using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject gameOverUI;

    public static bool GameIsOver;

    private void Start()
    {
        GameIsOver = false;
    }

    private void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.lives <= 0)
            EndGame();

    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
