using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            _inventory.SetActive(!_inventory.activeInHierarchy);
        }
    }
}
