using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRef;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRef = GetComponent<SpriteRenderer>();
    }

    public void SetupSpeed(float speed) 
    {
        _animator.SetFloat("Speed", speed);
    }

    public void SetupDirection(Vector2 direction) 
    {
        _animator.SetFloat("Horizontal", direction.x);

        _spriteRef.flipX = direction.x < 0;

        _animator.SetFloat("Vertical", direction.y);
    }
}
