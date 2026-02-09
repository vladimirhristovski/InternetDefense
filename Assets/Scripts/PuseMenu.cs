using UnityEngine;
using UnityEngine.SceneManagement;

public class PuseMenu : MonoBehaviour
{
    public string mainMenu = "MainMenu";
    
    public GameObject ui;
    
    public SceneFader sceneFader;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        TogglePauseMenu();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        TogglePauseMenu();
        sceneFader.FadeTo(mainMenu);    
    }
}
