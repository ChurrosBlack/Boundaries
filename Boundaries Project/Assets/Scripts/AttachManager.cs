using UnityEngine;
using System.Collections;

public class AttachManager : MonoBehaviour
{
    [SerializeField]
    HingeJoint2D boyJoint; 
    [SerializeField]
    KeyCode keyCode = KeyCode.Q;
    float distanceAbleToAttach;
    [SerializeField]
    Transform boy;
    [SerializeField]
    Transform girl;
    PlayerController boyController;
    PlayerController girlController;

    void Start()
    {
        boyController = boy.gameObject.GetComponent<PlayerController>();
        girlController = girl.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            boyJoint.enabled = !boyJoint.enabled;
        }

        boyController.enabled = !boyJoint.enabled;
        girlController.enabled = boyJoint.enabled;
    }

    
}
