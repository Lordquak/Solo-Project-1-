using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickup : Interactable
{

    public Item item;   // Item to put in the inventory on pickup

    // When the player interacts with the item
    void OnMouseDown()
    {
        PickUp(); // Pick it up on mouse click
    }
    // Pick up the item
    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);    // Add to inventory

        // If successfully picked up
        if (wasPickedUp)
            Destroy(gameObject);    // Destroy item from scene
    }


}
