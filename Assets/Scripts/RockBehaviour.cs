using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    public GameObject Rock;
    public GameController GameControllerInstance;

    private Rigidbody2D rb2d;

    private void Start()
    {
        GameControllerInstance = FindObjectOfType<GameController>();
    }
}
