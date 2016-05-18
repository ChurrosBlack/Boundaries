using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    /// <summary>
    /// Salva uma posição como checkpoint
    /// </summary>
    public Vector2 checkPoint;
    public Vector2 checkPointGirlPosition;
    public Vector2 checkPointBoyPosition;
    AttachManager attachManager;
    public Transform boyTransform;
    public Transform girlTransform;
    public bool together;

    bool boyWasOnLadderArea;

    public void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
    }


    public void SaveCheckPoint()
    {
        //Se eles estavam juntos quando o checkpoint for salvo        

        
        if (attachManager.attached)
        {
            checkPoint = boyTransform.position;
            checkPoint = girlTransform.position;
        }
        else
        {
            checkPointGirlPosition = girlTransform.position;
            checkPointBoyPosition = boyTransform.position;
        }

        boyWasOnLadderArea = boyTransform.GetComponent<LadderController>().onArea;
    }

    public void ReturnToCheckPointTogether()
    {
        print("Entered ReturnToCheckPoint");
        boyTransform.position = checkPoint; 
        girlTransform.position = checkPoint;
        attachManager.boyJoint.gameObject.transform.position = checkPoint;
        attachManager.boyJoint.enabled = true;
        boyTransform.GetComponent<LadderController>().onArea = boyWasOnLadderArea;
    }

    public void ReturnToCheckPointSeparated()
    {
        print("Entered ReturnToCheckPointSeparated");
        boyTransform.position = checkPointBoyPosition;
        girlTransform.position = checkPointGirlPosition;
        boyTransform.GetComponent<LadderController>().onArea = boyWasOnLadderArea;
    }
}
