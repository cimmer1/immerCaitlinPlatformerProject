using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MushroomBehaviour : MonoBehaviour
{
    public GameObject Mushroom;
    public float moveSpeed;
    //how close player can get before mushroom chases
    public float ChaseDistance;
    //keep track of player's position 
    public Transform playerTransform;
    //mushroom is chasing/not chasing player
    public bool isChasing;
    public GameController GameControllerInstance;

    void Update()
    {
        if (isChasing)
        {
            //if the enemy's position is greater than the player's position 
            if (transform.position.x > playerTransform.position.x)
            {
                //if the player is to the left of the enemy, it will move left towards the player 
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < playerTransform.position.x)
            {
                //if the player is to the right of the enemy, it will move right towards the player 
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        //not chasing 
        else
        {
            //calculate the distance between objects
            if (Vector2.Distance(transform.position, playerTransform.position) < ChaseDistance)
            {
                //if the player is within chase distance, the enemy will chase 
                isChasing = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water Blast")
        {
            Destroy(gameObject);
        }
    }
}
