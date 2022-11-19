using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public void Play() 
    {
        SceneManager.LoadScene("DesertL1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
