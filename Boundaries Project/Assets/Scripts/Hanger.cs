using UnityEngine;
using System.Collections;

public class Hanger : MonoBehaviour
{
    /// <summary>
    /// Deve conter um CircleCollider2D Trigger mostrando a área que pode ser Attachable!
    /// E para o método OnTriggerStay2D funcionar né :D
    /// </summary>
    AttachManager attachManager;
    float distance;
    Transform boy;

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
        boy = GameObject.FindGameObjectWithTag("Boy").GetComponent<Transform>();
        this.GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void Update()
    {
        //if (attachManager.boyJoint.enabled && attachManager.bodyToConnect == this.GetComponent<Rigidbody2D>())
        //{
        //    attached = true;
        //}

        //if (attached)
        //{
        //    attachManager.ableTo = true;
        //}
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Detec Enter PRESS Q TO ATTACH!!" + gameObject.name);
            attachManager.ableTo = true;
            attachManager.bodyToConnect = this.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Exited");
            attachManager.ableTo = false;
            attachManager.bodyToConnect = null;
        }
    }


}
