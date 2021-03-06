﻿using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{

    /*
    * Classe que controla o funcionamento de plafatorma giratória verificando se player ("Girl") está sobre ela.
    * @author /Sephhhh - https://www.reddit.com/user/Sephhhh
    * @Edit Marcos Vinicis Lima Silva
    * @since Classe criada em 12/05/2016 
    */


    bool isOverPlataform = false; //Váriavel de controle de player("Girl") para verificar se a mesma está sobre a plataforma.
    
    public Vector2 Velocity = new Vector2(1, 0);

    [Range(0, 5)]
    public float RotateSpeed = 1f;
    [Range(0, 5)]
    public float RotateRadiusX = 1f;
    [Range(0, 5)]
    public float RotateRadiusY = 1f;

    public bool Clockwise = true;

    public Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void FixedUpdate()
    {


            //_centre += Velocity * Time.deltaTime;

            _angle += (Clockwise ? RotateSpeed : -RotateSpeed) * Time.deltaTime;

            var x = Mathf.Sin(_angle) * RotateRadiusX;
            var y = Mathf.Cos(_angle) * RotateRadiusY;

            transform.position = _centre + new Vector2(x, y);

           
        
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_centre, 0.1f);
        Gizmos.DrawLine(_centre, transform.position);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Girl")
        {
            isOverPlataform = true;
            Debug.Log("Plataform");


        }
    }
}
