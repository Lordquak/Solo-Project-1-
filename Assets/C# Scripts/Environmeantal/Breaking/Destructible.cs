using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    private void OnMouseDown()
    {
        Instantiate(destroyedVersion, gameObject.transform.position, gameObject.transform.rotation );
        Destroy(gameObject);
    }
}
