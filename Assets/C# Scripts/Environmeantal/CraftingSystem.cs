using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CraftingSystem {
   /* private const int GRID_SIZE = 3;

    private Item[,] itemArray;
   public CraftingSystem()
    {
        itemArray = new Item[GRID_SIZE, GRID_SIZE];
    }

    private bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public Item GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    private void SetItem(Item item, int x, int y)
    {
        itemArray[x, y] = item;
    }

    private void IncreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount++;
    }

    private void DecreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount--;
    }

    private void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    private bool TryAddItem(int x, int y)
    {
        if (IsEmpty(x, y))
        {
            SetItem(item, x, y);
        }
        else
        {
            if (Item.itemType == GetItme(x, y).itemType)
            {
                IncreaseItemAmount(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }*/
}
