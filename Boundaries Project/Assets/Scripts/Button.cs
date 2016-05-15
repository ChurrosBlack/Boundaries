using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    /// <summary>
    /// Script de comportamento de botão
    /// Pode ser usado também para alavancas, etc
    /// </summary>
   
    AttachManager attachManager; //Necessita ter referência à este componente poiso botão de interação é o mesmo
    bool girlClose;
    [SerializeField]
    bool activated = false;
    Transform[] objAttachedTo; //Porta ou barreira atrelado ao botão para ser ativado

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && girlClose)
        {
            print("detected");
            try
            {
                print("uhu");
                activated = !activated;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{

    //    if (col.tag == "Boy")
    //    {
    //        attachManager.ableTo = false;
    //        girlClose = true;
    //    }

    //    if (col.tag == "Girl")
    //    {
    //        activated = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.tag == "Boy")
    //    {
    //        girlClose = false;
    //        attachManager.ableTo = true;
    //    }

    //    if (col.tag == "Girl")
    //    {
    //        activated = true;
    //    }
    //}

    //void ActivateObjectsAttached()
    //{
    //    for (int i = 0; i < objAttachedTo.Length; i++)
    //    {
    //        objAttachedTo[i].GetComponent<Barrier>().open = true;
    //    }
    //}
}

