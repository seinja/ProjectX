using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController2D _character;

    public Transform Character => _character.transform;

    public static GameManager Instance;
    public ItemContainer ItemContainer;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }
}
