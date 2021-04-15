using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField]
    Image icon;
    Item item;

    void Awake() 
    {
        icon.sprite = null;    
    }
    // Update is called once per frame
    public void Init(Item item)
    {
        this.item = item;
        icon.sprite = item.Icon;
    }

    public void OnClickCell()
    {
        if (item == null)
            return;

        GameManager.inst.playerInventory.Items.Remove(item);
        Buff buff = new Buff
        {
            type = item.BuffType,
            additiveBonus = item.Value,
            isUsed = false
        };

        //GameManager.inst.buffRecieverContainer.buffReciever.AddBuff(buff);
        GameManager.inst.playerController.MyBuffReciever.AddBuff(buff);

        // Delete icon
        icon.sprite = null;
        item = null;
    }

    public void ClearCell()
    {
        icon.sprite = null;
        item = null;
    }
}
