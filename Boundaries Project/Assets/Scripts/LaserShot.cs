using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    /// <summary>
    /// Atira laser via Raycast para cima, de timeToshoot em timeToShoot
    /// Quando atira o laser permanece visível por timeShooting segundos
    /// </summary>
   public float timeToShoot;
   public float timeShooting = 3f;
   public float auxTime;
   public float shotDistance = 10f;
   public LayerMask playerLayer;
   GameOverManager gameOverManager;
    void Start()
    {
        auxTime = timeToShoot;
        gameOverManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameOverManager>();
    }

    void Update()
    {
        timeToShoot -= Time.deltaTime;
        if (timeToShoot<=0)
        {
            Shoot();
            StartCoroutine(Wait(timeShooting));
            timeToShoot = auxTime;

        }
    }

    void Shoot()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, shotDistance, playerLayer))
        {
            print("Cant go bro, look at that drop right there nigguh");
            gameOverManager.boyDead = true;
            gameOverManager.girlDead = true;
        }
    }

   public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
