using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    /// <summary>
    /// Atira laser via Raycast para cima, de timeToshoot em timeToShoot
    /// Quando atira o laser permanece visível por timeShooting segundos
    /// </summary>
   public float timeShoting = 3f;
   public float timeToShot = 3f;
   public float auxTime;
   public float shotDistance = 10f;
   public LayerMask playerLayer;
   GameOverManager gameOverManager;
   bool shooting = false;
    void Start()
    {
        auxTime = timeShoting;
        gameOverManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOverManager>();
    }

    void Update()
    {
        if (!shooting)
        {
            timeShoting -= Time.deltaTime;
            if (timeShoting <= 0)
            {
                shooting = true;
                StartCoroutine(Wait());

            }
            else
            {
                Shoot();
            }
        }
        
    }

    void Shoot()
    {
        print("shot");
        Debug.DrawRay(transform.position, transform.up * shotDistance, Color.yellow);
        if (Physics2D.Raycast(transform.position, transform.up, shotDistance, playerLayer))
        {
            print("Cant go bro, look at that drop right there nigguh");
            gameOverManager.boyDead = true;
            gameOverManager.girlDead = true;
        }
    }

   public IEnumerator Wait()
    {

        yield return new WaitForSeconds(timeToShot);
        timeShoting = auxTime;
        shooting = false;
   }
}
