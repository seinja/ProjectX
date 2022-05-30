using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemContainerCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemContainer container = target as ItemContainer;

        if(GUILayout.Button("Clear container")) 
        {
            foreach (var el in container.Slots) 
            {
                //el.Clear();
            }
        }

        DrawDefaultInspector();
    }
}
