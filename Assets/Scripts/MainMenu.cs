using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsCanvas;
    public GameObject mainMenuCanvas;
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("GAME CLOSED");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Chourouk Scene");
    }

    public void Controls()
    {
        controlsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void mainMenu()
    {
        controlsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
