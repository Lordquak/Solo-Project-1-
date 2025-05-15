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
            // Rotate to look at the camera
            transform.LookAt(mainCamera.transform);

            // Optional: Lock X and Z rotation to keep upright (face only rotates around Y)
            Vector3 currentRotation = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
        }
    }
}
