using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogue;
    
    public string GetDescription()
    {
        return "Talk to Skeleton";
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            dialogueManager.BeginDialogue(dialogue);
        }
    }
}