using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrouchFootstepSytem : MonoBehaviour
{
    [Range(0, 20f)]
    public float frequency = 10.0f;

    public UnityEvent onFootStep;

    private AudioSource audioSource; // Reference to the AudioSource component
    public float volume = 0.2f;  // Default volume (can be changed from the Inspector)

    float Sin;

    bool isTriggered = false;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl))  // Check if Control is being pressed
        {
            StartFootsteps();
        }

        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if (inputMagnitude > 0)
        {

            StartFootsteps();
        }
    }

    private void StartFootsteps()
    {

        Sin = Mathf.Sin(Time.time * frequency);

        if (Sin > 0.97f && isTriggered == false)
        {

            isTriggered = true;
            Debug.Log("Tic");
            onFootStep.Invoke();

        }
        else if (isTriggered == true && Sin < -0.97f)
        {

            isTriggered = false;
        }
    }

}
