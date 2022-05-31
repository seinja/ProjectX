using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] private GameObject _dragIcon;
    [SerializeField] private ItemSlot _itemSlot;

    private RectTransform _iconTransform;
    private Image _dragIconImage;

    private void Start()
    {
        _itemSlot = new ItemSlot();
        _iconTransform = _dragIcon.GetComponent<RectTransform>();
        _dragIconImage = _dragIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if (!_dragIcon.activeInHierarchy) return;

        _iconTransform.position = Input.mousePosition;

        if (EventSystem.current.IsPointerOverGameObject() == false) 
        {
            Vector3 worldPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPostion.z = 0;

            ItemSpawnManager.Instane.SpawnItem(worldPostion, _itemSlot.Item, _itemSlot.SizeOfStack);
            _itemSlot.Clear();
            _dragIcon.SetActive(false);
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if (this._itemSlot.Item == null)
        {
            this._itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else 
        {
            Item item = itemSlot.Item;
            int count = itemSlot.SizeOfStack;

            itemSlot.Copy(this._itemSlot);
            this._itemSlot.Set(item, count);
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (_itemSlot.Item != null) 
        {
            _dragIcon.SetActive(true);
            _dragIconImage.sprite = _itemSlot.Item.Icon;
            return;
        }

        _dragIcon.SetActive(false);
    }
}
