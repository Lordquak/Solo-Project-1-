using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMonitor : MonoBehaviour
{
    public GameObject target; // The object to monitor
    private Vector3 lastPosition;
    public float checkDelay = 0.2f;
    public float movementThreshold = 0.001f;

    void Start()
    {
        if (target != null)
            lastPosition = target.transform.position;

        InvokeRepeating(nameof(CheckMovement), checkDelay, checkDelay);
    }

    void CheckMovement()
    {
        if (target == null) return;

        Vector3 currentPosition = target.transform.position;
        float distance = Vector3.Distance(currentPosition, lastPosition);
        bool isMoving = distance > movementThreshold;

        if (!isMoving && !target.activeSelf)
        {
            target.SetActive(true); // Turn on if not moving
        }
        else if (isMoving && target.activeSelf)
        {
            target.SetActive(false); // Turn off if moving
        }

        lastPosition = currentPosition;
    }
}
