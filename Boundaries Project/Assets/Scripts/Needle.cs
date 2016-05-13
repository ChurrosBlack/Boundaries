using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour
{
    GameOverManager gameOverManager;

    void Start()
    {
        gameOverManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOverManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Boy":
                gameOverManager.boyDead = true;
                break;
            case "Girl":
                gameOverManager.girlDead = true;
                break;
            default:
                break;
        }
    }
}
