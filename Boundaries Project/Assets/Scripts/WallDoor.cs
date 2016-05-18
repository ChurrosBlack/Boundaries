using UnityEngine;
using System.Collections;

public class WallDoor : MonoBehaviour
{
    LadderController ladderController;
    SpriteRenderer boySprite;
    public EdgeCollider2D ladderLinked;
    bool front = false;
    public bool onDoorArea;
    public int frontLayer =1;
    public int backLayer = -1;
    void Start()
    {
        ladderController = GameObject.FindGameObjectWithTag("Boy").GetComponent<LadderController>();
        boySprite = GameObject.FindGameObjectWithTag("Boy").GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (onDoorArea)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                front = !front;
            }
            ladderLinked.isTrigger = front;
            if (front) boySprite.sortingOrder = frontLayer; else boySprite.sortingOrder = backLayer;
            return;
        }
        ladderLinked.isTrigger = true;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            onDoorArea = true;
            if (boySprite.sortingOrder == backLayer)
            {
                front = false;
            }
            else
            {
                front = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            onDoorArea = false;
        }
    }
}
