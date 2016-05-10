using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Direction dir;
    public KeyCode pauseButton;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        if (input > 0)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            dir = Direction.RIGHT;
        }

        if (input < 0)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            dir = Direction.LEFT;
        }

    }  

    public enum Direction
    {
        RIGHT,
        LEFT
    }
}


