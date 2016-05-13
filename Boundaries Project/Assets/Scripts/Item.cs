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

   

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Girl" || col.tag == "Boy")
        {
            inventory.AddItem(this);
            this.gameObject.SetActive(false);
        }
    }

   


}
