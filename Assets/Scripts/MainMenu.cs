using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("GAME CLOSED");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Chourouk Scene");
    }
}
