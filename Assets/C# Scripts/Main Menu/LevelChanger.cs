using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public Button yourButton;

    void Start()
    {
        // Ensure the button is not null and add a listener for the button click
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }

    // The method that will be called when the button is clicked
    void OnButtonClick()
    {
        FadeToLevel(1);
    }
    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
}
