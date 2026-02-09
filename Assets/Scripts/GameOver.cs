using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string mainMenu = "MainMenu";
    public SceneFader sceneFader;

    public void Retry()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(mainMenu);
    }
}
