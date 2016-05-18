using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryChecker : MonoBehaviour
{
    public Inventory inventoryRef;
    public Barrier[] barriers;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Girl")
        {
            OpenBarriers();
        }
    }

    void OpenBarriers()
    {
        for (int i = 0; i < inventoryRef.inventory.Count; i++)
        {
            barriers[i].actualPower++;
        }
    }
}
