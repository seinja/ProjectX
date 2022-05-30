using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemContainer _inventory;
    [SerializeField] private List<ItemSlotButton> _itemSlots;
    

    private void Start()
    {
        SetIndex();

        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    private void Show() 
    {
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            if (_inventory.Slots[i].Item != null)
            {
                _itemSlots[i].Setup(_inventory.Slots[i]);
            }
            else 
            {
                _itemSlots[i].Clean();
            }
        }
    }

    private void SetIndex() 
    {
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            _itemSlots[i].SetIndex(i);
        }
    }
}
