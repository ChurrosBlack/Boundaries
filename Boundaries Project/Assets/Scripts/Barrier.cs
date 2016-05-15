﻿using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    bool open;
    [SerializeField]
    int powerToOpen = 1; //Quantos botões necessários para abrir a porta
    public int actualPower;
    //Às vezes uma barreira necessita de mais de um portão para abrir

    //Caso prefira usar com animator, que acredito ser mais fácil
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        open = actualPower >= powerToOpen;
        anim.SetBool("Open", open);
    }
}