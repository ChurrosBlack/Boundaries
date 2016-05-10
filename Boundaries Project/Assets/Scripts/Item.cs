﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public int id;
    [SerializeField]
    string name;
    AttachManager attachManager;
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
