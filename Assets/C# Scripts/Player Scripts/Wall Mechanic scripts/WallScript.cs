using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;

public class WallScript : MonoBehaviour
{
    public Camera cam;
    public float detectRange = 20;

    [Space]
    [Header("WALL BUILDING PARAMETERS")]
    public GameObject wallMarker;
    public GameObject wallcube;
    public int wallCubeAmount = 5;
    public float wallCubeDistance = 1f;
    public float wallDuration = 5f;
    public float updateRate = 0.1f;


    private Vector3 destination;
    private Quaternion rotation;
    private bool wallMarkerActive;
    private bool inRange;
    private bool wallBuilding;

    void Start()
    {
        wallMarker.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            wallMarkerActive = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            wallMarkerActive = false;
        }

        if (wallMarkerActive)
        {
            UpdateWallMarker();
        }
        else
        {
            wallMarker.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && inRange && wallBuilding)
        {
            BuildWall();
        }
    }

    void UpdateWallMarker()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectRange))
        {
            inRange = true;
            destination = hit.point;
            rotation = Quaternion.LookRotation(ray.direction);
        }
        else
        {
            inRange = false; 
        }

        if (inRange)
        {
            wallMarker.transform.position = destination;
            rotation = new Quaternion(wallMarker.transform.rotation.x, rotation.y, wallMarker.transform.rotation.z, wallMarker.transform.rotation.w);
            wallMarker.transform.rotation = rotation;
            wallMarker.SetActive(true);
        }
        else 
        
            wallMarker.SetActive(false);
        
        
        
    }

    void BuildWall()
    {
        wallBuilding = true;
        wallMarkerActive = false;
        GameObject wall = new GameObject();
        wall.transform.position = destination;
        wall.name = "Wall";

        for(int i=0; i<wallCubeAmount; i++)
        {
            var cube = Instantiate(wallcube, destination + new Vector3(i * wallCubeDistance, 0, 0), Quaternion.identity) as GameObject;
            cube.transform.SetParent(wall.transform); 
        }

        wall.transform.rotation = rotation;
        wall.transform.Translate(new Vector3(-(int)(wallCubeAmount / 2)*wallCubeDistance, 0, 0), Space.Self);

        wallBuilding = false;
        
        StartCoroutine(DestroyWall(wall));
    }

    IEnumerator DestroyWall (GameObject wallToDestroy)
    {
        float duration = wallDuration;
        

        while(duration > 0)
        {
            duration -= updateRate;

           

            yield return new WaitForSeconds(updateRate);
            if (duration <= 0)
                Destroy(wallToDestroy);
        }


    }
}
