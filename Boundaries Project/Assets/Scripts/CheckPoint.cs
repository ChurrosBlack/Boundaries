using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    /// <summary>
    /// Salva uma posição como checkpoint
    /// </summary>
    [HideInInspector]
    public Vector3 checkPoint;
    public void SaveCheckPoint(Vector3 position)
    {
        checkPoint = position;
    }
  
}
