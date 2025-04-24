using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue" , fileName = "New Dialogue")]
public class DialogueManager : MonoBehaviour
{
    [SerializeField] List<Dialogue> choices = new List<Dialogue>();

    [SerializeField] string optionName;
    [SerializeField] string dialoguetext;

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform buttonsParent;
    [SerializeField] GameObject Playercontroller;
    

    public string OptionName
    {
        get { 
            return optionName;
        }
    }

    public List<Dialogue> Choices {
        get
        {
            return choices;
        }
    }

    public string DialogueText { 
      get
        {
            return dialoguetext;
        }
    }

    public void beginDialogue(Dialogue dialogue)
    {
        if(dialogue.Choices.Count == 0)
        {
            dialoguePanel.SetActive(false);

            Playercontroller.ToggleMovement(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            return;
        }

        Playercontroller.ToggleMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
