using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public Item itemData;

    public void Init(Item item)
    {
        itemData = item;
        // Optional: set visuals, name, etc. from itemData
    }

}
