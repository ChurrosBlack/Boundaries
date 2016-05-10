using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform[] targets = new Transform[2];
    public Vector2 midTarget;
    public float distance;
    public float delay;
    public float xTarget;
    public float yTarget;
    public int targetIndex;

    Camera cam;
    float minOrthosize = 4.52f;

    PlayerController[] player = new PlayerController[2];
    int side;
    void Start()
    {
        cam = GetComponent<Camera>();
        player[0] = targets[0].GetComponent<PlayerController>();
        player[1] = targets[1].GetComponent<PlayerController>();
    }
    void Update()
    {
        if (player[targetIndex].dir == PlayerController.Direction.RIGHT)side = 1;
        else side = -1;

        if (player[1].GetComponent<HingeJoint2D>().enabled)
        {
            targetIndex = 0;
        }
        else
        {
            targetIndex = 1;
        }

        if (delay < 0)
        {
            delay = 0;
        }

        midTarget = new Vector2((targets[0].position.x + targets[1].position.x)/2, (targets[0].position.y + targets[1].position.y)/2);
        print(Vector2.Distance(targets[0].position, targets[1].position));


        transform.position = new Vector3(Mathf.Lerp(transform.position.x, midTarget.x + (xTarget * side) , delay),
            Mathf.Lerp(transform.position.y, midTarget.y + yTarget , delay),
            distance
            );
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        cam.orthographicSize = Vector2.Distance(targets[0].position, targets[1].position)/2;
        if (cam.orthographicSize <= minOrthosize) cam.orthographicSize = minOrthosize;

    }
}
