using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float _speed;

    [SerializeField] private PlayerAnimation _playerAnimation;

    private Rigidbody2D _rb;

    private Vector2 _movementDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementDirection.x = Input.GetAxisRaw("Horizontal");
        _movementDirection.y = Input.GetAxisRaw("Vertical");

        SendDataToAnimator();

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            InventorySystem.Instance.OnOffInventory();
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movementDirection * _speed * Time.fixedDeltaTime);
    }

    private void SendDataToAnimator() 
    {
        _playerAnimation.SetupSpeed(_movementDirection.sqrMagnitude);
        _playerAnimation.SetupDirection(_movementDirection);
    }


}
