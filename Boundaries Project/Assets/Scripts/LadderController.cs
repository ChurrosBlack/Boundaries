using UnityEngine;
using System.Collections;

public class LadderController : MonoBehaviour
{
    /// <summary>
    /// Usado para admnistrar os controles quando jogador estiver sob
    /// área escalável: Escadas, cordas, grades
    /// </summary>
    PlayerController playerController;
    float speed;
    public bool onLadder;
    public bool onArea;
    float gravityScale;
    Rigidbody2D rb;
    GameOverManager gameOverManager;
    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = playerController.transform.GetComponent<Rigidbody2D>();
        speed = playerController.speed;
        gravityScale = playerController.transform.GetComponent<Rigidbody2D>().gravityScale;
        gameOverManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (onArea && Input.GetKeyDown(KeyCode.Q))
        {
            onLadder = true;
        }

        if (!onArea)
        {
            onLadder = false;
        }

        playerController.enabled = !onLadder;


        if (onLadder)
        {
            rb.Sleep();

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            MoveHorizontal(horizontalInput);
            MoveVertical(verticalInput);
            
        }
        else
        {
            rb.WakeUp();
        }

    }

    void MoveHorizontal(float dir)
    {
        if (dir > 0)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        if (dir < 0)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void MoveVertical(float dir)
    {
        if (dir > 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }

        if (dir < 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
