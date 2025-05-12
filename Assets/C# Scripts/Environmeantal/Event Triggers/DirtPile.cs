using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPile : MonoBehaviour
{
    public GameObject textPanel;  // Assign your UI Panel with Text
    public float displayTime = 3f;  // Time to show the text (3 seconds)

    private void Start()
    {
        if (textPanel != null)
            textPanel.SetActive(false);  // Hide text at start
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);

        if (other.CompareTag("Shovel"))
        {
            Debug.Log("Shovel hit Dirt Pile! Removing Dirt Pile!");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit Dirt Pile! Showing text.");
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
