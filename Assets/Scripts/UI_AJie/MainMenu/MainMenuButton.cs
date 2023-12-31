using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("ChooseRootDNA");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ProducersButton()
    {
        SceneManager.LoadScene("");
    }
}
