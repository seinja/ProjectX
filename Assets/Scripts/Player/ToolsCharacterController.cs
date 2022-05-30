using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    [SerializeField] private float _offSetDistance;
    [SerializeField] private float _sizeOfInteractableArea;


    private CharacterController2D _character;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _character = GetComponent<CharacterController2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            UseTool();
        }
    }

    private void UseTool() 
    {
        Vector2 position = _rb.position + _character.LastCharacterDirection * _offSetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);

        foreach (var el in colliders) 
        {
            ToolHit hit = el.GetComponent<ToolHit>();
            if (hit != null) 
            {
                hit.Hit();
                break;
            }
        }

    }
}
