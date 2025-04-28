using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, set the inventory to be off (hidden)
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);  // Inventory is initially hidden
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Tab key was pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the visibility of the inventory panel
            ToggleInventoryPanel();


           // Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }

    // Toggle Inventory visibility
    public void ToggleInventoryPanel()
    {
        if (inventoryPanel != null)
        {
            // Toggle the inventory panel visibility
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    
}
