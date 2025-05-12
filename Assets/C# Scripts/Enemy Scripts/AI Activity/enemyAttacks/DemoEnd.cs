using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoEnd : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "MainMenu";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breaker"))
        {
            SceneManager.LoadScene(sceneToLoad);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    
}

