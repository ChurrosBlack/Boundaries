using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    [HideInInspector]
    public Vector3 checkPoint;
    public void SaveCheckPoint(Vector3 position)
    {
        checkPoint = position;
    }
  
}
