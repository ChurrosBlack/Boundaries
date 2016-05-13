using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Direction dir;
    public KeyCode pauseButton;
    Rigidbody2D rb;


    /// <summary>
    /// Componente responsável pelos controles, tanto o garoto quanto a menina levam o componente
    /// No garoto este script deve estar desativado quando estiver anexado à algo
    /// </summary>

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        if (input > 0)
        {
            MoveRight();
        }

        if (input < 0)
        {
            MoveLeft();
        }


    } 

    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        dir = Direction.RIGHT;
    }

    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        dir = Direction.LEFT;
    }

    public enum Direction
    {
        RIGHT,
        LEFT
    }
}


