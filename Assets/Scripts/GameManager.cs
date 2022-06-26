using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject Player;
    public ItemContainer Inventory;
    

    private void Awake()
    {
        Instance = this;
    }
}
