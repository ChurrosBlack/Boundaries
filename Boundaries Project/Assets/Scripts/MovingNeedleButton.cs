using UnityEngine;
using System.Collections;

public class MovingNeedleButton : MonoBehaviour
{
    /// <summary>
    /// Script para Puzzle de agulhas que se movem nas plataformas
    /// segundo documentação LD
    /// </summary>
    public bool activated = false;
    [SerializeField]
    MovingNeedle[] objctsAttached;
    [Range(1,3)]
    public int id;
  
    public void ActivateObjectsAttached(bool activate)
    {
        for (int i = 0; i < objctsAttached.Length; i++)
        {
            objctsAttached[i].GetComponent<MovingNeedle>().activated = activate;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Girl")
        {
            print("Girl detec");
            activated = true;
            ActivateObjectsAttached(activated);
        }
    }

 
}
