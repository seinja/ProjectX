using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _pickUpItemPrefab;


    public static ItemSpawnManager Instane;

    private void Awake()
    {
        if (Instane == null) 
        {
            Instane = this;
        }
    }

    public void SpawnItem(Vector3 position, Item item, int count) 
    {
        var dropItem = Instantiate(_pickUpItemPrefab, position, Quaternion.identity);
        dropItem.GetComponent<PickUpItem>().Set(item, count);
    }
}
