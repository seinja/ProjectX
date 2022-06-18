using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlotButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemsCountText;

    private int _itemIndex;

    public void SetIndex(int index) 
    {
        _itemIndex = index;
    }

    public void Setup(ItemSlot slot) 
    {
        _itemIcon.gameObject.SetActive(true);
        _itemIcon.sprite = slot.Item.Icon;

        if (slot.Item.Stacable) 
        {
            _itemsCountText.gameObject.SetActive(true);
            _itemsCountText.text = slot.SizeOfStack.ToString();
            return;
        }

        _itemsCountText.gameObject.SetActive(false);
    }

    public void Clean() 
    {
        _itemIcon.sprite = null;
        _itemsCountText.gameObject.SetActive(false);
        _itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryPanel inventory = transform.parent.GetComponent<InventoryPanel>();
        inventory.OnClick(_itemIndex);

    }

    public void Highlight(bool b) 
    {
        Debug.Log("Highlight");
        // Add some effect of highlight 
    }


}
