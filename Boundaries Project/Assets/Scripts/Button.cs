using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    /// <summary>
    /// Script de comportamento de botão
    /// Pode ser usado também para alavancas, etc
    /// </summary>
    [SerializeField]
    string name;
    AttachManager attachManager; //Necessita ter referência à este componente poiso botão de interação é o mesmo
    bool girlClose;
    [SerializeField]
    bool activated = false;

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
                attachManager.ableTo = true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Girl")
        {
            attachManager.ableTo = false;
            girlClose = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Girl")
        {
            attachManager.ableTo = true;
            girlClose = false;
        }
    }


}

