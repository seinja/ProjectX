using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemSlot 
{
    public Item Item;
    public int SizeOfStack;

    public void Copy(ItemSlot slot) 
    {
        Item = slot.Item;
        SizeOfStack = slot.SizeOfStack;
    }

    public void Set(Item item, int count) 
    {
        this.Item = item;
        this.SizeOfStack = count;
    }

    public void Clear() 
    {
        Item = null;
        SizeOfStack = 0;
    }
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> Slots;


    public void Add(Item item, int count = 1) 
    {
        if (item.Stacable) 
        {
            var element = Slots.Find(x => x.Item == item);
            if (element != null)
            {
                element.SizeOfStack += count;
            }
            else 
            {
                element = Slots.Find(x => x.Item == null);
                if (element != null) 
                {
                    element.Item = item;
                    element.SizeOfStack = count;
                }
            }
            return;
        }

        ItemSlot slot = Slots.Find(x => x.Item == null);
        if(slot != null) 
        {
            slot.Item = item;
        }
    }
}
