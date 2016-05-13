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
    bool playerClose;
    Inventory inventory;

    void Start()
    {
        try
        {
            attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
            inventory = GameObject.FindGameObjectWithTag("Manager").gameObject.GetComponent<Inventory>();

        }
        catch (System.Exception)
        {
            print("Manager not found by:" + this);
            throw;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerClose)
        {
            print("detected");
            try
            {
                print("uhu");
                inventory.AddItem(this);
                this.gameObject.SetActive(false);
                //attachManager.ableTo = true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Girl" || col.tag == "Boy")
        {
            attachManager.ableTo = false;
            playerClose = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Girl" || col.tag == "Boy")
        {
            //attachManager.ableTo = true;
            playerClose = false;
        }
    }


}
