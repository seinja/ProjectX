using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolbarPanel : InventoryPanel
{
    [SerializeField] ToolBarController _toolBar;

    private int _currentSelectedTool;

    public override void OnClick(int id)
    {
        _toolBar.Set(id);
        Highlight(id);
    }

    public void Highlight(int id) 
    {
        ItemSlots[_currentSelectedTool].Highlight(false);
        _currentSelectedTool = id;
        ItemSlots[_currentSelectedTool].Highlight(true);
    }
}
