using UnityEngine;
using System.Collections;

public class PushBox : MonoBehaviour
{
    /// <summary>
    /// Confirmar se realmente será necessário
    /// </summary>
    PlayerController girlController;
    public float minDist;
    public bool onPush;

    void Start()
    {
        girlController = GetComponent<PlayerController>();
    }

    
}
