using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemBase))]
public class ItemBaseEditor : Editor
{
    ItemBase itemBase;

    void Awake() 
    {
        itemBase = (ItemBase)target;
    }
    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("New Item"))
            itemBase.CreateItem();

        if (GUILayout.Button("Delete Item"))
            itemBase.RemoveItem();

        if (GUILayout.Button("<=="))
            itemBase.PrevIndex();

        if (GUILayout.Button("==>"))
            itemBase.NextItem();

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
