using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehaviour : MonoBehaviour
{
    public Transform Player;
    public Transform ShootPos;
    public float walkSpeed;
    public float Range, TimeBTWShots;
    public float ShootSpeed;
    private float distanceToPlayer;
    //public GameObject SnowBall;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        //calculates the distance between 2 game objects
        //distanceToPlayer = Vector2.Distance(transform.position, Player.position);

        //if (distanceToPlayer < Range)
        //{
            
            //Shoot();
        //}

    //}
    
    //IEnumerator Shoot()
    //{
        //wait for a certain amount of time
        //yield return new WaitForSeconds(TimeBTWShots);
        //GameObject newSnowBall = Instantiate(SnowBall, ShootPos.position, Quaternion.identity);

        //newSnowBall.GetComponent<Rigidbody2D>().velocity = new Vector2(ShootSpeed * Time.fixedDeltaTime, 0f);
    //}
}
