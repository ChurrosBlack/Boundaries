using UnityEngine;
using System.Collections;

public class MovingNeedle : MonoBehaviour
{
    /// <summary>
    /// Script para Puzzle de agulhas que se movem nas plataformas
    /// segundo documentação LD
    /// </summary>
    public bool activated;
    public Transform end;
    Transform start;
    float speed;
    void Start()
    {
        activated = false;
        start = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    void MoveRight()
    {
        if (Vector2.Distance(transform.position, start.position) <= 0.3)
        {
            return;
        }
        else
        {
            transform.position = new Vector2(
                transform.position.x - speed * Time.deltaTime,
                transform.position.y
                );
        }
    }

    void MoveLeft()
    {
        if (Vector2.Distance(transform.position, end.position) <= 0.3)
        {
            return;
        }
        else
        {
            transform.position = new Vector2(
                transform.position.x + speed * Time.deltaTime,
                transform.position.y
                );
        }
    }
}
