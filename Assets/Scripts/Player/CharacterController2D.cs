using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [Header("Character settings")]
    [SerializeField] [Range(3.5f, 5f)] private float _speed;

    [Header("Animation link")]
    [SerializeField] private PlayerAnimation _playerAnimation;

    private Rigidbody2D _rb;
    private Vector2 _movementVector;
    private Vector2 _lastCharacterDirection;

    public Vector2 LastCharacterDirection => _lastCharacterDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (_movementVector.x != 0 || _movementVector.y != 0) 
        {
            _lastCharacterDirection = new Vector2(_movementVector.x, _movementVector.y);
        }
    }

    private void FixedUpdate()
    {
        Move();
        SendDataToAnimation();
    }

    private void Move() 
    {
        _rb.velocity = _movementVector * _speed;
    }

    private void SendDataToAnimation() 
    {
        _playerAnimation.SetupSpeed(_movementVector.sqrMagnitude);
        _playerAnimation.SetupDirection(_movementVector);
    }
}
