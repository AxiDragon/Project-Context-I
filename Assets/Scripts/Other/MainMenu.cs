using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        LoadingScreen.sceneNumber = 11;
        SceneManager.LoadScene("ConceptExplenationSlide");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
