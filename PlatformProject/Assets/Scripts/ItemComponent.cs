using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField]
    ItemType itemType;
    Item item;
    SpriteRenderer myRenderer;
    // Start is called before the first frame update
    public Item Item
    {
        get {return item;}
    }

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        item = GameManager.inst.itemDataBase.GetItemFromID((int)itemType);
        myRenderer.sprite = item.Icon;

        GameManager.inst.itemComponentContainer.Add(gameObject, this);
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}

public enum ItemType {HealthPotion, AttackPotion, ForcePoton}