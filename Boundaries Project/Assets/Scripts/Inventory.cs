using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// Cria lista de inventário para garota
    /// </summary>
    [SerializeField]
    List<Item> inventory = new List<Item>();
    CheckPoint checkpointSave;

    void Start()
    {
        checkpointSave = GetComponent<CheckPoint>();
    }

    public void AddItem(Item i)
    {
        inventory.Add(i);
        checkpointSave.SaveCheckPoint(transform.position);
    }
}
