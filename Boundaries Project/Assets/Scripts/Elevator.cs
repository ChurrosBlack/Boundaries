using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{

    /*
    * Classe que controla o funcionamento de plafatorma ELEVADOR verificando se player ("Girl") está sobre ela.
    * 
    * @author Marcos Vinicis Lima Silva
    * @since Classe criada em 12/05/2016 
    */

    [SerializeField]
    Transform plataform; //Elevador 

    [SerializeField]
    Transform startTransform; // Ponto inicial

    [SerializeField]
    Transform endTransform; //Ponto final

    [SerializeField]
    float moveSpeed; //Velocidade de movimentação do Elevador

   
    bool isOverElevator = false; //Váriavel de controle de player("Girl") para verificar se a mesma está sobre a plataforma ELEVADOR.
    Rigidbody2D rb2D;
    Vector3 direction; //Direção para controlar subir e descer
    Transform destination; //Destino a ser seguido pelo elevador

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SetDestination(startTransform);
    }

     

    void FixedUpdate()
    {
        while (isOverElevator)
        {
            rb2D.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);

            if (Vector3.Distance(plataform.position, destination.position) < moveSpeed * Time.fixedDeltaTime)
            {
                SetDestination(destination == startTransform ? endTransform : startTransform);
            }

            isOverElevator = !isOverElevator;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(startTransform.position, plataform.localScale);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(endTransform.position, plataform.localScale);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(startTransform.position, plataform.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(endTransform.position, plataform.position);
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - plataform.position).normalized;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Girl")
        {
            isOverElevator = !isOverElevator;
            
        }
    }
	
	

}
