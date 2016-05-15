using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{

    /// <summary>
    /// Trata objeto anexado como "escalável"
    /// </summary>
    LadderController ladderController;

    void Start()
    {
        ladderController = GameObject.FindGameObjectWithTag("Boy").GetComponent<LadderController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boy")
        {
            print("On LAdder Area");
            ladderController.onArea = !ladderController.onArea;
        }
    }

    
}
