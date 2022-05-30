using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform _character;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _pickUpDistance = 1.5f;
    [SerializeField] float _timeToLeve = 10f;
    [SerializeField] private Item _item;


    [SerializeField] private int _count = 1;

    private void Awake()
    {
        _character = GameManager.Instance.Character;
    }


    private void Update()
    {
        _timeToLeve -= Time.deltaTime;
        if (_timeToLeve <= 0)
        {
            Destroy(gameObject);
        }


        float distance = Vector3.Distance(transform.position, _character.position);
        if (distance > _pickUpDistance) 
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _character.position, _speed * Time.deltaTime);

        if (distance < .1f) 
        {
            if (GameManager.Instance.ItemContainer != null)
            {
                GameManager.Instance.ItemContainer.Add(_item, _count);
                Destroy(gameObject);
            }
            else 
            {
                Debug.Log("GameManager Instance didn't have ItemContainer SO ");
            }
        }
    }
}
