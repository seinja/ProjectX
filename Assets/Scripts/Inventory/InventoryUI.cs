using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private UIItemSlot[] _itemSlots;

    public void OnUpdateInventory() 
    {
        DrawInventory();
    }

    public void DrawInventory() 
    {
        var temp = InventorySystem.Instance.Inventory;

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp.Count != 0) 
            {
                _itemSlots[i].Set(temp[i]);
            }

        }

        foreach (var el in _itemSlots) 
        {
            if (el.IsSet == false) 
            {
                el.Clear();
            }
        }
    }
}
