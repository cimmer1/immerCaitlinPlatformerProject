using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            float xMove = Input.GetAxis("Horizontal");
            Vector2 newPos = transform.position;

            newPos.x += xMove * Speed * Time.deltaTime;

            Debug.Log(newPos);
            transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float xMove = Input.GetAxis("Horizontal");
            Vector2 newPos = transform.position;

            newPos.x += xMove * Speed * Time.deltaTime;

            Debug.Log(newPos);
            transform.position = newPos;
        }
    }
}
