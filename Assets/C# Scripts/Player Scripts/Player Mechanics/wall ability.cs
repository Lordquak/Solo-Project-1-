using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wallability : MonoBehaviour
{
    public GameObject wall;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(wall);
        }
    }
}
