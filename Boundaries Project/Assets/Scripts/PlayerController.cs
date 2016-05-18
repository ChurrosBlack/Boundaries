using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Direction dir;
    public KeyCode pauseButton;
    public KeyCode interactButton;
    Rigidbody2D rb;
    public float verticalInput;
    public float horizontalInput;
    bool interact;

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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        interact = Input.GetKey(interactButton);

        if (horizontalInput > 0)
        {
            MoveRight();
        }

        if (horizontalInput < 0)
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


