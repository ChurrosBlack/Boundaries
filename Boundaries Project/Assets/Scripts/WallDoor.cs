using UnityEngine;
using System.Collections;

public class WallDoor : MonoBehaviour
{
    LadderController ladderController;
    SpriteRenderer boySprite;
    LayerMask layerToGo;
    LayerMask originalLayer;
    public PolygonCollider2D ladderLinked;
    public bool front = true;
    public bool onDoorArea;
    public int frontLayer = 1;
    public int backLayer = -1;
    void Start()
    {
        ladderController = GameObject.FindGameObjectWithTag("Boy").GetComponent<LadderController>();
        boySprite = GameObject.FindGameObjectWithTag("Boy").GetComponent<SpriteRenderer>();
        layerToGo = LayerMask.NameToLayer("Behind");
        originalLayer = LayerMask.NameToLayer("Player");
    }


    void Update()
    {
        if (onDoorArea)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                front = !front;
                if (front == true)
                {
                    boySprite.sortingOrder = frontLayer; 
                    boySprite.transform.gameObject.layer = originalLayer;
                }
                else
                {
                    boySprite.sortingOrder = backLayer;
                    boySprite.transform.gameObject.layer = layerToGo;
                }
 
            }

            return;
        }

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
