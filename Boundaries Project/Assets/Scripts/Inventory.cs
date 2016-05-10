using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> inventory = new List<Item>();
    

    public void AddItem(Item i)
    {
        inventory.Add(i);
    }
}
