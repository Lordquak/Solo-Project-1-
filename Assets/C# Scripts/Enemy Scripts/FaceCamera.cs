using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Get reference to the main camera
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // Rotate to face the camera
            transform.forward = mainCamera.transform.forward;
        }
    }
}
