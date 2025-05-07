using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject Panel;
    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene"); // Replace with your actual scene name
        
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace with your actual scene name

    }

    public void OpenOptions()
    {
        Panel.SetActive(true);
    }
    public void CloseOptions()
    {
        Panel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in editor
#endif
    }
}
