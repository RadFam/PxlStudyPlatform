using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Cell[] cells;
    [SerializeField]
    int cellsCount;
    [SerializeField]
    Cell cellPrefab;
    [SerializeField]
    Transform rootParent;
    
    void Init()
    {
        cells = new Cell[cellsCount];
        for (int i = 0; i < cellsCount; ++i)
        {
            cells[i] = Instantiate(cellPrefab, rootParent);
        }
        cellPrefab.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnEnable()
    {
        if (cells == null || cells.Length <= 0)
        {
            Init();
        }

        var inventory = GameManager.inst.playerInventory;
        for (int i = 0; i < inventory.Items.Count; ++i)
        {
            if (i < cells.Length)
            {
                cells[i].Init(inventory.Items[i]);
            }
        }
    }
}
