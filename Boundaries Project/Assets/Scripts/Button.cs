using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    /// <summary>
    /// Script de comportamento de botão
    /// Pode ser usado também para alavancas, etc
    /// </summary>
   
    AttachManager attachManager; //Necessita ter referência à este componente poiso botão de interação é o mesmo
    bool boyClose;
    [SerializeField]
    bool activated = false;
    [SerializeField]
    Transform[] objAttachedTo; //Porta ou barreira atrelado ao botão para ser ativado

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && boyClose && !activated)
        {
            print("detected");
            try
            {
                print("Button" + gameObject.name + " :" +activated);
                activated = true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    void ActivateObjectsAttached()
    {
        for (int i = 0; i < objAttachedTo.Length; i++)
        {
            switch (objAttachedTo[i].tag)
            {
                case "Barrier":
                    objAttachedTo[i].GetComponent<Barrier>().actualPower++;
                    break;
                case "Elevator":
                    objAttachedTo[i].GetComponent<Elevator>().actualPower++;
                    break;
                case "Platform":
                    objAttachedTo[i].GetComponent<Plataform>().actualPower++;
                    break;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Boy")
        {
            boyClose = true;
        }

        if (col.tag == "Girl")
        {
            activated = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            boyClose = false;
        }

   
    }


}

