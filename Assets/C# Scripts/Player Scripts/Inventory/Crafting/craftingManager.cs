using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftingManager : MonoBehaviour
{
    public Inventory inventory; // Reference to your inventory

    public bool CanCraft(CraftingRecipe recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            if (inventory.GetItemCount(ingredient.item) < ingredient.quantity)
                return false;
        }
        return true;
    }

    public void Craft(CraftingRecipe recipe)
    {
        if (!CanCraft(recipe)) return;

        // Remove ingredients
        foreach (var ingredient in recipe.ingredients)
        {
            inventory.RemoveMultiple(ingredient.item, ingredient.quantity);
        }

        // Add result
        for (int i = 0; i < recipe.resultAmount; i++)
        {
            inventory.Add(recipe.result);
        }

        Debug.Log("Crafted " + recipe.result.name);
    }
}
