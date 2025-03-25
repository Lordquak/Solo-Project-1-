using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public Rigidbody rb;
    public bool isBroken;

    void Start()
    {
        rb.isKinematic = true;
    }

     void Update()
    {
        if (isBroken == true)
        {
            rb.isKinematic = false;
        }
    }

    private void OnMouseDown()
    {
       
        
            isBroken = true;
        
    }
}
