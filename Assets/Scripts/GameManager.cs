using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    
    public GameObject gameOverUI;
    public GameObject winGameUI;
    
    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinGame()
    {
        GameIsOver = true;
        winGameUI.SetActive(true);
    }
}
