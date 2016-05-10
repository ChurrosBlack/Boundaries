using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BoySense : MonoBehaviour
{
    GameObject[] Items;
    float distance;
    SenseStages senseStages;
    float farDist;
    float closeDist;

    void Start()
    {
        Items = GameObject.FindGameObjectsWithTag("Item");
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, ClosestItem());
        //TODO: Especificar quais distâncias serão trocados os estágios do sentido do rapaz;
        if (distance > farDist) senseStages = SenseStages.FAR;
        if (distance <= farDist) senseStages = SenseStages.MID;
        if (distance <= closeDist) senseStages = SenseStages.CLOSE;


        switch (senseStages)
        {
            case SenseStages.FAR:
                break;
            case SenseStages.MID:
                break;
            case SenseStages.CLOSE:
                break;
            default:
                break;
        }
    }

    Vector2 ClosestItem()
    {
        Vector2 closestItem = new Vector2();
        for (int i = 0; i < Items.Length; i++)
        {
            if (i == 0) closestItem = Items[i].transform.position;
            else
            {
                if (Vector2.Distance(transform.position, Items[i].transform.position) < Vector2.Distance(transform.position, closestItem))
                {
                    closestItem = Items[i].transform.position;
                }
            }
        }
        return closestItem;
    }

    public enum SenseStages
    {
        FAR,
        MID,
        CLOSE
    }
}
