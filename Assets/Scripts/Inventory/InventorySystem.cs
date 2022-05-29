using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryUI;

    public static InventorySystem Instance;

    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> Inventory { get; private set; }

    public Canvas InvetoryCanvas => transform.GetComponent<Canvas>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();


        _inventoryUI.SetActive(false);
    }

    public void OnOffInventory()
    {
        _inventoryUI.SetActive(!_inventoryUI.activeInHierarchy);
        _inventoryUI.GetComponent<InventoryUI>().DrawInventory();
    }

    public void Add(InventoryItemData refData)
    {
        if (_itemDictionary.TryGetValue(refData, out InventoryItem item))
        {
            item.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(refData);
            Inventory.Add(newItem);
            _itemDictionary.Add(refData, newItem);
        }

        _inventoryUI.GetComponent<InventoryUI>().DrawInventory();
    }

    public void Remove(InventoryItemData refData)
    {
        if (_itemDictionary.TryGetValue(refData, out InventoryItem item))
        {
            item.RemoveFromStack();

            if (item.StackSize == 0)
            {
                Inventory.Remove(item);
                _itemDictionary.Remove(refData);
            }
        }

        _inventoryUI.GetComponent<InventoryUI>().DrawInventory();
    }
}
