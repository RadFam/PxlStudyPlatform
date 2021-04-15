using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuffReciever : MonoBehaviour
{
    List<Buff> buffs;
    public Action OnBuffChanges;

    public List<Buff> Buffs
    {
        get{return buffs;}
    }
    void Start()
    {
        GameManager.inst.buffRecieverContainer.Add(gameObject, this);
        buffs = new List<Buff>();
    }

    public void AddBuff(Buff buff)
    {
        if (!buffs.Contains(buff))
        {
            buffs.Add(buff);
        }

        if (OnBuffChanges != null)
            OnBuffChanges();
    }

    public void RemoveBuff(Buff buff)
    {
        if (buffs.Contains(buff))
        {
            buffs.Remove(buff);
        }

        if (OnBuffChanges != null)
            OnBuffChanges();
    }
}
