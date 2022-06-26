using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [Serializable]
    public class ItemSlot
    {
        public Item Item;
        public int Count;
    }


    [CreateAssetMenu(menuName = "Data/Item Container")]
    public class ItemContainer : ScriptableObject
    {
        public Action AddItem;
        public List<ItemSlot> Slots;

        public void Add(Item item, int count)
        {
            if (item.Stackable)
            {
                ItemSlot itemSlot = Slots.Find(x => x.Item == item);
                if (itemSlot != null)
                {
                    itemSlot.Count += count;
                }
                else
                {
                    itemSlot = Slots.Find(x => x.Item == null);
                    if (itemSlot != null)
                    {
                        itemSlot.Item = item;
                        itemSlot.Count = count;
                    }
                }
            }
            else
            {
                ItemSlot itemSlot = Slots.Find(x => x.Item == null);
                {
                    if (itemSlot != null)
                    {
                        itemSlot.Item = item;
                    }
                }
            }

            AddItem?.Invoke();
        }
    }
}
