using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        //find the game object with the tag "game music"
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        //if the music object's length is greater than 1 destroy it 
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
