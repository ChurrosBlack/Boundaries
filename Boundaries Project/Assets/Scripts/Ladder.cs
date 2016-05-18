using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{

    /// <summary>
    /// Trata objeto anexado como "escalável"
    /// </summary>
    LadderController ladderController;
    AttachManager attachManager;
    bool inside;
    void Start()
    {
        ladderController = GameObject.FindGameObjectWithTag("Boy").GetComponent<LadderController>();
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            if(attachManager.attached)
            {
                ladderController.onArea = false;
                return;
            }
            print("On LAdder Area");
            ladderController.onArea = !ladderController.onArea;
            EdgeCollider2D edge = new EdgeCollider2D();

        }
        
    }

    
}
