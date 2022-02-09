using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();
    }

    public void PlayTheGame()
    {
        SceneManager.LoadScene("Main");
    }
}
