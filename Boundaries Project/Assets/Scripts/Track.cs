using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour
{
    public enum Direction
    {
        UP,
        RIGHT,
        LEFT,
        DOWN,
    }

    public Direction dir;
    public float speed;
    Vector2 force;
    float defaultBoyGravity = -.15f;

    void Start()
    {
        switch (dir)
        {
            case Direction.UP:
                force = Vector2.up;
                break;
            case Direction.RIGHT:
                force = Vector2.right;
                break;
            case Direction.LEFT:
                force = Vector2.left;
                break;
            case Direction.DOWN:
                force = Vector2.down;
                break;
            default:
                force = Vector2.up;
                break;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Track detec");
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(force * speed);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("Player Exitted");
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = defaultBoyGravity;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
