using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarController : MonoBehaviour
{
    [SerializeField] private int _toolBarSize = 5;

    private int _selectedTool;


    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;

        if (delta == 0) return;

        if (delta > 0)
        {
            _selectedTool += 1;
            _selectedTool = (_selectedTool >= _toolBarSize ? 0 : _selectedTool);
        }
        else 
        {
            _selectedTool -= 1;
            _selectedTool = (_selectedTool <= 0 ? _toolBarSize - 1 : _selectedTool);
        }

        Debug.Log(_selectedTool);
    }
}
