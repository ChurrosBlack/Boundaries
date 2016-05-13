using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    public bool open;
     
    //Caso prefira usar com animator, que acredito ser mais fácil
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        anim.SetBool("Open", open);
    }
}
