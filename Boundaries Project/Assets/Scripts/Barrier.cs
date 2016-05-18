using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    bool open;
    [SerializeField]
    public int powerToOpen = 1; //Quantos botões necessários para abrir a porta
    public int actualPower;
    //Às vezes uma barreira necessita de mais de um portão para abrir

    void Start()
    {

    }

    void Update()
    {
        open = actualPower >= powerToOpen;
    }
}
