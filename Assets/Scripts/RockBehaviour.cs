using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    public float Speed = 7; 
    public GameObject Rock;
    public GameController GameControllerInstance;

    private Rigidbody2D rb2d;

    private void Start()
    {
        GameControllerInstance = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
