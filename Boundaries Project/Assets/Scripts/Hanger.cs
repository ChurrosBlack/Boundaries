using UnityEngine;
using System.Collections;

public class Hanger : MonoBehaviour
{
    AttachManager attachManager;
    float distance;
    Transform boy;

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
        boy = GameObject.FindGameObjectWithTag("Boy").GetComponent<Transform>();
    }

    void Update()
    {
        distance = Vector2.Distance(boy.transform.position, transform.position);

        if(distance <= attachManager.minDistToAttach)
        {
            //Dentro da distância mínima
            print("Detec Enter PRESS Q TO ATTACH!!");
            attachManager.ableTo = true;
            attachManager.bodyToConnect = this.GetComponent<Rigidbody2D>();
        }
        else
        {
            print("Detec Exit");
            attachManager.ableTo = false;
            attachManager.bodyToConnect = null;
        }



    }

}
