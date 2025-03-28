using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshRebake : MonoBehaviour
{
    public NavMeshSurface navMeshSurface; // Assign in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Rebaking NavMesh...");
            navMeshSurface.BuildNavMesh();
        }
    }
}
