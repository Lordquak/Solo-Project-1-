using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class wallability : MonoBehaviour
{
    public GameObject wall;
    public NavMeshSurface navMeshSurface;
    public LayerMask groundLayer;
    public float wallHeightOffset = 0.1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 spawnPosition = gameObject.transform.position + gameObject.transform.forward * 10f;
            GameObject newWall = Instantiate(wall, spawnPosition, Quaternion.identity);



            newWall.transform.rotation = Quaternion.Euler(0f, newWall.transform.eulerAngles.y, newWall.transform.eulerAngles.z);

        }

    }
}
