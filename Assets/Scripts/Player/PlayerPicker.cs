using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    private INteractable _currentObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out INteractable item)) 
        {
            _currentObject = item;
        }
    }

    private void Update()
    {
        if (_currentObject == null) return;

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            _currentObject.Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out INteractable item))
        {
            _currentObject = null;
        }
    }

}
