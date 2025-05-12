using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tleport : MonoBehaviour
{
    public Transform teleportDestination;  // Where to teleport the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breaker"))
        {
            Debug.Log("Player entered teleport trigger!");

            // Teleport the player to the destination position
            other.transform.position = teleportDestination.position;

            // Optional: Reset player velocity if using Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
