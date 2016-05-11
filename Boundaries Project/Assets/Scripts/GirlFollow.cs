using UnityEngine;
using System.Collections;

public class GirlFollow : MonoBehaviour
{
    Transform boyTransform;
    PlayerController girlController;
    AttachManager attachManager;
    public Rigidbody2D rb;
    public float deviation = 2f; //desvio

    bool active;
    void Start()
    {
        girlController = GetComponent<PlayerController>();
        try
        {
            boyTransform = GameObject.FindGameObjectWithTag("Boy").GetComponent<Transform>();
            attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
        }
        catch (System.Exception)
        {
            print("Certifique de que as tags estão corretas");
            throw;
        }
    }

    void Update()
    {
        if (attachManager.boyJoint.connectedBody == rb && attachManager.boyJoint.enabled)
        {
            active = false;
        }
        else
        {
            active = true;
        }

        if (active)
        {
            if (Mathf.Abs(transform.position.x - boyTransform.position.x) <= deviation)
            {
                print("Pare...pegue no bum bum");
                return;
            }

            if (boyTransform.position.x > transform.position.x)
            {
                girlController.MoveRight();
                print("Moving Right:" + transform.position.x);
            }
            else
            {
                if (boyTransform.position.x < transform.position.x)
                {
                    girlController.MoveLeft();
                    print("Moving Left" + transform.position.x);
                }
            }

        }
    }
}
