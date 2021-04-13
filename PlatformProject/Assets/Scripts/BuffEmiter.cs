using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEmiter : MonoBehaviour
{
    [SerializeField]
    Buff buff;

    void OnTriggerEnter2D(Collider2D col) {
        if (GameManager.inst.buffRecieverContainer.ContainsKey(col.gameObject))
        {
            var reciever = GameManager.inst.buffRecieverContainer[col.gameObject];
            reciever.AddBuff(buff);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (GameManager.inst.buffRecieverContainer.ContainsKey(col.gameObject))
        {
            var reciever = GameManager.inst.buffRecieverContainer[col.gameObject];
            reciever.RemoveBuff(buff);
        }
    }
}

[System.Serializable]
public class Buff
{
    public BuffType type;
    public float additiveBonus;
    public float multipleBonus;
}

public enum BuffType {Damage, Force, Armor}