using UnityEngine;

public class WinGame : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
