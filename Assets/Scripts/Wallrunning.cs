using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrunning : MonoBehaviour
{
    public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxWallSpeed;
    bool isWallRight, isWallLeft;
    bool isWallRunning;
    public float maxWallRunCameraTilt, wallrunCameraTilt;

    private void WallRunInput()
    {
        if (Input.GetKey(KeyCode.D) && isWallRight) StartWallRun();
        if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallRun();
    }
    private void StartWallRun()
    {
        rb
    }
    private void StopWallRun()
    {

    }
    private void CheckForWall()
    {
        isWallRight = Physics.Raycast(transform.position, DeviceOrientation.LandscapeRight, 1f, whatIsWall);
        isWallRight = Physics.Raycast(transform.position, DeviceOrientation.LandscapeRight, 1f, whatIsWall);
    }

}
