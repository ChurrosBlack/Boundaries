using UnityEngine;
using System.Collections;

public class WindBlow : MonoBehaviour
{
    [SerializeField]
    float windForce;
    AttachManager attachManager;
    [SerializeField]Direction dir;
    Vector2 force;

    void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
        switch (dir)
        {
            case Direction.RIGHT:
                force = Vector2.right;
                break;
            case Direction.LEFT:
                force = Vector2.left;
                break;
            case Direction.UP:
                force = Vector2.up;
                break;
            case Direction.DOWN:
                force = Vector2.down;
                break;
            default:
                break;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        try
        {
            if (col.gameObject.GetComponent<LadderController>().onLadder)
                return;
        }
        catch (System.Exception)
        {
            
            throw;
        }

        col.gameObject.GetComponent<Rigidbody2D>().AddForce(force * windForce);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    enum Direction
    {
        RIGHT,
        LEFT,
        UP,
        DOWN

    }
}
