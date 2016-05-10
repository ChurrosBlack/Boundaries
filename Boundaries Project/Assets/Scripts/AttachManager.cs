using UnityEngine;
using System.Collections;

public class AttachManager : MonoBehaviour
{
    [SerializeField]
    HingeJoint2D boyJoint; 
    
    public KeyCode keyCode = KeyCode.Q;
    //float distanceAbleToAttach;
    [SerializeField]
    Transform boy;
    [SerializeField]
    Transform girl;
    PlayerController boyController;
    PlayerController girlController;


    public bool ableTo; //Caso ela esteja perto de um item ela não deve soltar a mão do rapaz

    void Start()
    {
        boyController = boy.gameObject.GetComponent<PlayerController>();
        girlController = girl.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(keyCode) && ableTo)
        {
            boyJoint.enabled = !boyJoint.enabled;
        }

        //Intercala os controles de cada personagem
        boyController.enabled = !boyJoint.enabled;
        girlController.enabled = boyJoint.enabled;
    }

    
}
