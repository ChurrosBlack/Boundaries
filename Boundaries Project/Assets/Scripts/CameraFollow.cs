using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// Câmera segue ambos os jogadores, podendo expandir seu tamanho em caso de distância dos dois objetos
    /// </summary>

    public Transform[] targets = new Transform[2];
    public Vector2 midTarget; //Posição do ponto exato de metade da distância entre os dois corpos
    public float distance;
    public float delay; //Pequeno atraso no movimento da câmera para torná-lo mais fluido e suave
    public float xTarget; //Deslocamento em x
    public float yTarget; //Deslocamento em y
    public int targetIndex; //Caso estejam soltos um do outro a câmera precisa levar em consideração o alvo que está sendo controlado, no caso, o garoto

    Camera cam;
    float minOrthosize = 4.52f; 

    PlayerController[] player = new PlayerController[2];
    int side; //Variável para controle de que lado o jogador está olhando, podendo ser 1 ou -1 (Direita ou esquerda)
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
