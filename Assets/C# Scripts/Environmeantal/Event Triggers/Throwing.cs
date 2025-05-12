using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject textPanel;  // Assign your UI Panel with Text
    public float displayTime = 3f;  // Time to show the text (3 seconds)

    private bool hasTriggered = false;  // Flag to ensure text is shown only once

    private void Start()
    {
        if (textPanel != null)
            textPanel.SetActive(false);  // Hide text at start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;  // If text has already been triggered, do nothing

        if (other.CompareTag("Breaker"))  // Check if the collider is tagged as "Breaker"
        {
            Debug.Log("Breaker entered trigger! Showing text for 3 seconds.");
            if (textPanel != null)
            {
                StartCoroutine(ShowTextForTime());
                hasTriggered = true;  // Set flag to prevent it from triggering again
            }
        }
    }

    private IEnumerator ShowTextForTime()
    {
        textPanel.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        textPanel.SetActive(false);
    }
}
