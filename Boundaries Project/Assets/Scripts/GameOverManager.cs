using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    /// <summary>
    /// Anexar ao manager da cena
    /// </summary>
    public bool boyDead= false;
    public bool girlDead = false;
    AttachManager attachManager;
    [SerializeField]
    AnimationClip deathAnim;
    [SerializeField]
    CheckPoint checkPoint;
    [SerializeField]
    float delay = 1f;  //Delay antes de retornar ao Checkpoint após possível animação de morte
    
   

    void Update()
    {
        if (boyDead || girlDead)
        {
            StartCoroutine(WaitAnim(/* deathAnim.length + delay*/ delay));
        }
    }

    

    //Bom para fazer uma animação de morte antes retornar ao CheckPoint
    public IEnumerator WaitAnim(float time)
    {
        print("Entered");
        yield return new WaitForSeconds(time);
        print("Waited");
        boyDead = false;
        girlDead = false;
        checkPoint.ReturnToCheckPoint();
    }
}
