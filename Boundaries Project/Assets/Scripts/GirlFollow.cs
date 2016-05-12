using UnityEngine;
using System.Collections;

public class GirlFollow : MonoBehaviour
{
    /// <summary>
    /// Script responsável pelo mecanismo de seguir a garoto quando ele estiver solto
    /// E também parar de andar caso exista algo à sua frente
    /// </summary>
    /// 

    public bool active;
    Transform boyTransform;
    PlayerController girlController;
    AttachManager attachManager;
    public Rigidbody2D rb;
    public float deviation = 2f; //desvio
    public float sightDistance = 3f;
    public LayerMask threatLayer;
    [SerializeField]
    bool blockMoveTowards; //Bloquear movimento em certa direção
    [SerializeField]
    bool blockMoveBackwards;

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
            switch (girlController.dir)
            {
                case PlayerController.Direction.RIGHT:
                    blockMoveTowards = ThreatOnSight(girlController.dir);
                    blockMoveBackwards = false;
                    break;
                case PlayerController.Direction.LEFT:
                    blockMoveBackwards = ThreatOnSight(girlController.dir);
                    blockMoveTowards = false;
                    break;
                default:
                    break;
            }


            //Caso esteja perto do rapaz
            if (Mathf.Abs(transform.position.x - boyTransform.position.x) <= deviation)
            {
                return;

            }

            if (boyTransform.position.x > transform.position.x && !blockMoveTowards)
            {
                girlController.MoveRight();
            }
            else
            {
                if (boyTransform.position.x < transform.position.x && !blockMoveBackwards)
                {
                    girlController.MoveLeft();
                }
            }


        }
    }

    bool ThreatOnSight(PlayerController.Direction dir)
    {
        Vector2 direction = new Vector2();
        if (dir == PlayerController.Direction.RIGHT) direction = transform.right;
        else direction = transform.right * -1;
        
        Debug.DrawRay(transform.position, direction * sightDistance, Color.red);
        if (Physics2D.Raycast(transform.position, direction, sightDistance, threatLayer))
        {
            print("Cant go bro, look at that drop right there nigguh");
            return true;
        }
        return false;
    }

  
}
