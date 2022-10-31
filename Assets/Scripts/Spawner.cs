using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject RockPrefab;
    public float SecondsBetweenSpawns = 2;
    private float nextSpawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //if current time in game is > than next spawn time 
        if (Time.time > nextSpawnTime)
        {
            //next spawn time is equal to current time + the seconds between spawn
            nextSpawnTime = Time.time + SecondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-3, 40), Random.Range(10, 10));
            Instantiate(RockPrefab, spawnPosition, Quaternion.identity);
        }
      
    }
}
