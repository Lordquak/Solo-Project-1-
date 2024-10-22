using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

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

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
