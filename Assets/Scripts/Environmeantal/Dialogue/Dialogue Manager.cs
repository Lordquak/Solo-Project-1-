using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> Sentences;
    void Start()
    {
        Sentences = new Queue<string>();
    }

  
}
