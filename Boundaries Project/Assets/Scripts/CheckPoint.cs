using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    /// <summary>
    /// Salva uma posição como checkpoint
    /// </summary>
    public Vector3 checkPoint;
    AttachManager attachManager;


    public void Start()
    {
        attachManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AttachManager>();
    }


    public void SaveCheckPoint(Vector3 position)
    {
        checkPoint = position;
    }

    public void ReturnToCheckPoint()
    {
        transform.position = checkPoint;
        attachManager.boyJoint.gameObject.transform.position = checkPoint;
        attachManager.boyJoint.enabled = true;
    }
}
