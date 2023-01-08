using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deals with the players POV

public class PlayerCamera : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform player;
    float xRotation = 0f;
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }

    public void ChangeSens(float newSens)
    {
        mouseSens = newSens;
    }
}
