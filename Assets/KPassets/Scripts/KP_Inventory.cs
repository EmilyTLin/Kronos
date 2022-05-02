using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        Debug.Log("Inventory YAYY");

        AddItem(new Item { itemType = Item.ItemType.SQUARE, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
