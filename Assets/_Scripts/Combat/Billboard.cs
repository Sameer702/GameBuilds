using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keeps the health bar always looking at the camera

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
        
    }
}
