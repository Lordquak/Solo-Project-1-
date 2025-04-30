using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingButton : MonoBehaviour
{
    public CraftingRecipe recipe;
    public craftingManager manager;

    public void OnClickCraft()
    {
        manager.Craft(recipe);
    }
}
