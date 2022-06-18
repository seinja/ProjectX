using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private ItemContainer _inventory;

    public List<ItemSlotButton> ItemSlots;
    

    private void Start()
    {
        SetIndex();

        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show() 
    {
        for (int i = 0; i < _inventory.Slots.Count && i < ItemSlots.Count; i++)
        {
            if (_inventory.Slots[i].Item != null)
            {
                ItemSlots[i].Setup(_inventory.Slots[i]);
            }
            else 
            {
                ItemSlots[i].Clean();
            }
        }
    }

    private void SetIndex() 
    {
        for (int i = 0; i < _inventory.Slots.Count && i < ItemSlots.Count; i++)
        {
            ItemSlots[i].SetIndex(i);
        }
    }

    public virtual void OnClick(int id) 
    {

    }
}
