using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//displays the winning screen

public class WinningScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
