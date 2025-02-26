using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FootstepSystem : MonoBehaviour
{
	
	[Range(0, 20f)]
	public float frequency = 10.0f;

	public UnityEvent onFootStep;

	float Sin;

	bool isTriggered = false;

	void Update() {

        if (Input.GetKey(KeyCode.LeftControl))  // Check if Control is being pressed
        {
            // Control is pressed, do nothing (prevent footstep system from activating)
            return;
        }

        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

		if (inputMagnitude > 0) {

			StartFootsteps();
		}
	}

	private void StartFootsteps() {

		Sin = Mathf.Sin(Time.time * frequency);

		if (Sin > 0.97f && isTriggered == false) {

			isTriggered = true;
			Debug.Log("Tic");
			onFootStep.Invoke();

		} else if (isTriggered == true && Sin < -0.97f) {

			isTriggered = false;
		}
	}
 
}
