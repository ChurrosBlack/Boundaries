using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour
{
    /// <summary>
    /// Mecanismo de tubos é formado por uma estrutura de objetos em pares
    /// Cada qual com sua "saída", e nenhum dos lados funcionando explicitamente como entrada
    /// ou saída
    /// </summary>
    public Transform exit;
    Transform boy;
    public float time;
    public bool playerExiting;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Boy detec");

            if (!playerExiting)
            {
                try
                {
                    boy = col.GetComponent<Transform>();
                    Transport(exit);
                }
                catch (System.Exception)
                {

                    throw;
                } 
            }
        }

       
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            playerExiting = false;
        }
    }

    void Transport(Transform destination)
    {
        destination.GetComponent<Pipe>().playerExiting = true;
        boy.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Wait(time));
        boy.transform.position = destination.position;
        boy.GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
