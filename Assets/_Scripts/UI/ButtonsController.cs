using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls a lot of the UI buttons

public class ButtonsController : MonoBehaviour
{
    public GameObject menuButtons;
    public GameObject tutorialText;
    public void Play() 
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.level);
    }

    public void HowToPlay()
    {
        menuButtons.SetActive(false);
        tutorialText.SetActive(true);
    }

    public void Back()
    {
        menuButtons.SetActive(true);
        tutorialText.SetActive(false);
    }
}
