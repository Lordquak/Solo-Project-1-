using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouchstep : MonoBehaviour
{
    public AudioSource footstepsSound;

    void Update()
    {
       if (Input.GetKey(KeyCode.LeftControl))
       {
           footstepsSound.enabled = true;
       }
       else
       {
           footstepsSound.enabled = false;
       }

    }
}
