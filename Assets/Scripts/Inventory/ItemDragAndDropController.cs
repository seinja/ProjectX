using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;

    private void Start()
    {
        itemSlot = new ItemSlot();
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if (this.itemSlot.Item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else 
        {
            Item item = itemSlot.Item;
            int count = itemSlot.SizeOfStack;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
    }
}
