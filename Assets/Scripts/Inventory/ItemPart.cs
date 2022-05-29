using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemPart : MonoBehaviour
{
    [SerializeField] private InventoryItemData _referenceItemData;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.DOJump(collision.transform.position, 0.25f, 1, 0.25f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return; 

        transform.DOKill();
        InventorySystem.Instance.Add(_referenceItemData);
        Destroy(gameObject);
    }
}
