using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> items;
    public BuffReciever buffReciever;

    public List<Item> Items
    {
        get{return items;}
    }
    void Start()
    {
        items = new List<Item>();
        GameManager.inst.playerInventory = this;
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (GameManager.inst.itemComponentContainer.ContainsKey(col.gameObject))
        {
            var itemComponent = GameManager.inst.itemComponentContainer[col.gameObject];
            items.Add(itemComponent.Item);
            itemComponent.SelfDestroy();
        }
    }
}
