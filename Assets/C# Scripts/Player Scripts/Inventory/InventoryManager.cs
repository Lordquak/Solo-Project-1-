using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
            var itemicon = obj.transform.Find("Item/ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemicon.sprite = item.icon;
            
        }
    }
}
