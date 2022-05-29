using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Image _countImage;
    //private GameObject _collectObject;

    private InventoryItem _currentItem;

    public bool IsSet = false;
    public bool IsHotbar = false;

    private void Start()
    {
        if (IsHotbar) 
        {
            Clear();
        }
    }

    public void Set(InventoryItem item) 
    {
        OnUIParts();

        IsSet = true;

        _currentItem = item;
        _itemImage.sprite = item.Data.Icon;

        if (item.StackSize <= 1) 
        {
            //_collectObject.SetActive(false);
            return;
        }

        _countText.text = item.StackSize.ToString();
    }

    public void Clear() 
    {
        _itemImage.gameObject.SetActive(false);
        _countText.gameObject.SetActive(false);
        _countImage.gameObject.SetActive(false);
    }

    private void OnUIParts() 
    {
        _itemImage.gameObject.SetActive(true);
        _countText.gameObject.SetActive(true);
        _countImage.gameObject.SetActive(true);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemtransform = eventData.pointerDrag.transform;
        otherItemtransform.SetParent(transform);
        otherItemtransform.localPosition = Vector3.zero;
    }

    public void RemoveItem() 
    {
        _currentItem = null;
        _itemImage.gameObject.SetActive(false);
        _countText.gameObject.SetActive(false);
        _countImage.gameObject.SetActive(false);
    }
}
