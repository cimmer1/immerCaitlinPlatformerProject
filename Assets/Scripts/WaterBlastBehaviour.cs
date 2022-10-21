using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlastBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;

    //speed of the blast
    public float Speed = 1000.0f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Project(Vector2.right);
    }

    public void Project(Vector2 direction)
    {
        //once waterblast is fired it will move in that direction * the speed
        rb2d.AddForce(direction * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
