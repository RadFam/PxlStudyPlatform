using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Databases/Items")]
public class ItemBase : ScriptableObject
{
    [SerializeField, HideInInspector]
    List<Item> items;
    [SerializeField]
    Item currItem;
    int currIndex;

    public void CreateItem()
    {
        if (items == null)
        {
            items = new List<Item>();
        }

        Item item = new Item();
        items.Add(item);
        currItem = item;
        currIndex = items.Count - 1;
    }

    public void RemoveItem()
    {
        if (items == null)
            return;
        if (currItem == null)
            return;
        items.Remove(currItem);
        if (items.Count > 0)
        {
            currItem = items[0];
        }
        else
        {
            CreateItem();
        }
        currIndex = 0;
    }

    public void NextItem()
    {
        if (currIndex + 1 < items.Count)
        {
            currIndex++;
            currItem = items[currIndex];
        }
    }

    public void PrevIndex()
    {
        if (currIndex > 0)
        {
            currIndex--;
            currItem = items[currIndex];
        }
    }

    public Item GetItemFromID(int id)
    {
        return items.Find(x => x.ID == id);
    }
}

[System.Serializable]
public class Item
{
    [SerializeField]
    int id;
    [SerializeField]
    string itemName;
    [SerializeField]
    string description;
    [SerializeField]
    Sprite icon;
    [SerializeField]
    float value;
    [SerializeField]
    BuffType buffType;

    public int ID
    {
        get {return id;}
    }

    public string ItemName
    {
        get {return itemName;}
    }
    public string Description
    {
        get {return description;}
    }
    public Sprite Icon
    {
        get {return icon;}
    }
    public float Value
    {
        get {return value;}
    }
    public BuffType BuffType
    {
        get {return buffType;}
    }
}