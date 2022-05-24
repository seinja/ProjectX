using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, INteractable
{
    [SerializeField] private GameObject _interactUI;

    [SerializeField] private InventoryItemData _referenceItemData;

    private void Awake()
    {
        _interactUI.SetActive(false);
    }

    private void OnInteractUI()
    {
        _interactUI.SetActive(true);
    }

    private void OffInteractUI() 
    {
        _interactUI.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnInteractUI();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OffInteractUI();
        }
    }

    private void OnHandlePickUp()
    {
        InventorySystem.Instance.Add(_referenceItemData);
        Destroy(gameObject);
    }

    public void Interact()
    {
        OnHandlePickUp();
    }
}
