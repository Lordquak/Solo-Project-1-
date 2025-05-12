using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public GameObject textPanel;  // Assign your UI Panel in Inspector
    public float displayTime = 3f;  // Time to show the text (3 seconds)

    private void Start()
    {
        if (textPanel != null)
            textPanel.SetActive(false);  // Hide text at start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breaker"))  // You can change this to "Shovel" if needed
        {
            Debug.Log("Trigger entered! Showing text for 3 seconds.");
            if (textPanel != null)
                StartCoroutine(ShowTextForTime());
        }
    }

    private IEnumerator ShowTextForTime()
    {
        textPanel.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        textPanel.SetActive(false);
    }
}
