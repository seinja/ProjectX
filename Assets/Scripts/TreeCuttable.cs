using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] private int _amountToDrop = 2;
    [SerializeField] private GameObject _stick;

    public override void Hit()
    {
        for (int i = 0; i < _amountToDrop; i++) 
        {
            GameObject stick = Instantiate(_stick, transform.position, Quaternion.identity);
            stick.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 0.5f), Random.Range(0, 0.5f)));
            Destroy(gameObject);
        }
    }
}
