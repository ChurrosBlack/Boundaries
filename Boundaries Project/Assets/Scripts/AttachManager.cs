using UnityEngine;
using System.Collections;

public class AttachManager : MonoBehaviour
{
    /// <summary>
    /// Responsável pelo mecanismo de soltar/agarrar o garoto, o script deve permanecer em um terceiro objeto invisível ao jogador
    /// </summary>
    /// 
    [SerializeField]

    public HingeJoint2D boyJoint;

    public KeyCode keyCode = KeyCode.Q;
    //float distanceAbleToAttach; Settar distância minima para ocorrer o evento
    [SerializeField]
    Transform boy;
    [SerializeField]
    Transform girl;
    PlayerController boyController;
    PlayerController girlController;
    public Rigidbody2D bodyToConnect;
    [SerializeField]
    public float minDistToAttach = 4f;

    public bool ableTo; //Caso ela esteja perto de um item ela não deve soltar a mão do rapaz
    public bool attached;


    void Start()
    {
        boyController = boy.gameObject.GetComponent<PlayerController>();
        girlController = girl.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode) && attached)
        {
            Detach();
        }


        if (Input.GetKeyDown(keyCode) && ableTo && !attached)
        {
            print("Input Detected");
            Attach();
        }

        //Intercala os controles de cada personagem
        boyController.enabled = !boyJoint.enabled;
        girlController.enabled = boyJoint.enabled;
    }

    void Attach()
    {     
        boyJoint.connectedBody = bodyToConnect;
        boyJoint.enabled = true;
        attached = true;
    }

    void Detach()
    {
        if (!boyJoint.enabled)
        {
            return;
        }

        boyJoint.connectedBody = null;
        boyJoint.enabled = false;
        attached = false;
    }
}
