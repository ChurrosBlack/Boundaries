using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public Transform endPosition;
    Vector2 startPos;
    [SerializeField]
    float speed;

    public int actualPower;
    public int powerToTurnOn = 0;
    [SerializeField]
    Direction dir;
    bool girlOn;
    [SerializeField]
    float waitTime;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (actualPower >= powerToTurnOn ) 
            //&& girlOn
        {
            Move();
        }
    }

    void Move()
    {
        switch (dir)
        {
            case Direction.UP:
                transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y + speed * Time.deltaTime
                    );
                break;
            case Direction.DOWN:
                transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y - speed * Time.deltaTime
                    );
                break;
            case Direction.LEFT:
                transform.position = new Vector2(
                    transform.position.x - speed * Time.deltaTime,
                    transform.position.y
                    );
                break;
            case Direction.RIGHT:
                transform.position = new Vector2(
                   transform.position.x + speed * Time.deltaTime,
                   transform.position.y
                   );
                break;
            default:
                break;
        }


        if (Vector2.Distance(transform.position, endPosition.position) <= 0.3)
        {
            endPosition.position = startPos;
            startPos = transform.position;
            StartCoroutine(Wait());
            switch (dir)
            {
                case Direction.UP:
                    dir = Direction.DOWN;
                    break;
                case Direction.DOWN:
                    dir = Direction.UP;
                    break;
                case Direction.LEFT:
                    dir = Direction.RIGHT;
                    break;
                case Direction.RIGHT:
                    dir = Direction.LEFT;
                    break;
               
            }

        }
    }

    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Girl")
        {
            girlOn = true;
            col.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Girl")
        {
            girlOn = false;
            transform.DetachChildren();
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}



///*
//* Classe que controla o funcionamento de plafatorma ELEVADOR verificando se player ("Girl") está sobre ela.
//* 
//* @author Marcos Vinicis Lima Silva
//* @since Classe criada em 12/05/2016 
//*/

//[SerializeField]
//Transform plataform; //Elevador 

//[SerializeField]
//Transform startTransform; // Ponto inicial

//[SerializeField]
//Transform endTransform; //Ponto final

//[SerializeField]
//float moveSpeed; //Velocidade de movimentação do Elevador

//public int actualPower;
//public int powerToActivate;

//bool isOverElevator = false; //Váriavel de controle de player("Girl") para verificar se a mesma está sobre a plataforma ELEVADOR.
//Rigidbody2D rb2D;
//Vector3 direction; //Direção para controlar subir e descer
//Transform destination; //Destino a ser seguido pelo elevador

//void Start()
//{
//    rb2D = GetComponent<Rigidbody2D>();
//    SetDestination(startTransform);
//}



//void FixedUpdate()
//{
//    while (isOverElevator)
//    {
//        rb2D.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);

//        if (Vector3.Distance(plataform.position, destination.position) < moveSpeed * Time.fixedDeltaTime)
//        {
//            SetDestination(destination == startTransform ? endTransform : startTransform);
//        }

//        isOverElevator = !isOverElevator;
//    }
//}



//void SetDestination(Transform dest)
//{
//    destination = dest;
//    direction = (destination.position - plataform.position).normalized;
//}

//void OnTriggerStay2D(Collider2D collider)
//{
//    if (collider.gameObject.name == "Girl")
//    {
//        isOverElevator = !isOverElevator;

//    }
//}

