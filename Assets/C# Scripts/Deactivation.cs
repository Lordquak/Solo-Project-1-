using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivation : MonoBehaviour
{
    
    public MonoBehaviour scriptToDisable; // Assign the script in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            scriptToDisable.enabled = false; // Disables the script
        }
    }
}
