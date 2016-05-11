using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    /// <summary>
    /// Script de comportamento do Item
    /// </summary>
    public int id;
    [SerializeField]
    string name;
    AttachManager attachManager; //Necessita ter referência à este componente poiso botão de interação é o mesmo
    bool girlClose;
    Inventory inventory;

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
        inventory = GameObject.FindGameObjectWithTag("Girl").gameObject.GetComponent<Inventory>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && girlClose)
        {
            print("detected");
            try
            {
                print("uhu");
                inventory.AddItem(this);
                this.gameObject.SetActive(false);
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
            girlClose= true;
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
