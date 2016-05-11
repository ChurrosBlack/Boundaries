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
    float minDist = 1f;



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
            Attach();
        }

        //Intercala os controles de cada personagem
        boyController.enabled = !boyJoint.enabled;
        girlController.enabled = boyJoint.enabled;
    }

    void Attach()
    {
        if (bodyToConnect == null)
        {
            return;
        }

        boyJoint.connectedBody = bodyToConnect;
        boyJoint.enabled = !boyJoint.enabled;
    }
}
