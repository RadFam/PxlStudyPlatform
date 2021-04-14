using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField]
    ItemType itemType;
    Item item;
    SpriteRenderer myRenderer;
    Collider2D myCollider;
    bool isTaken;
    // Start is called before the first frame update
    public Item Item
    {
        get {return item;}
    }

    public bool IsTaken
    {
        get {return isTaken;}
        set {isTaken = value;}
    }

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
        item = GameManager.inst.itemDataBase.GetItemFromID((int)itemType);
        myRenderer.sprite = item.Icon;
        isTaken = false;

        GameManager.inst.itemComponentContainer.Add(gameObject, this);
    }

    public void DisableCollider()
    {
        myCollider.enabled = false;
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}

public enum ItemType {AttackPotion, ForcePotion, HealthPotion}