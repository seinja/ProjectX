using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private ItemContainer _inventory;
        [SerializeField] private List<InventoryButton> _buttons;

        private void Start()
        {
            SetIndex();
            Show();

            _inventory.AddItem += RefreshSlots();
        }

        private Action RefreshSlots()
        {
            Show();
            return null;
        }

        private void SetIndex()
        {
            for (var i = 0; i < _inventory.Slots.Count; i++)
            {
                _buttons[i].SetIndex(i);
            }
        }
        

        private void Show()
        {
            for (var i = 0; i < _inventory.Slots.Count; i++)
            {
                if (_inventory.Slots[i].Item == null)
                {
                    _buttons[i].Clean();
                }
                else
                {
                    _buttons[i].Set(_inventory.Slots[i]);
                }
            }
        }
    }
}
