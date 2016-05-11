using UnityEngine;
using System.Collections;

public class Hanger : MonoBehaviour
{
    AttachManager attachManager;

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Detec Enter PRESS Q TO ATTACH!!");
            attachManager.ableTo = true;
            attachManager.bodyToConnect = this.GetComponent<Rigidbody2D>();
        }
    }

    void OnExitEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Detec Exit");
            attachManager.ableTo = false;
            attachManager.bodyToConnect = null;
        }
    }
}
