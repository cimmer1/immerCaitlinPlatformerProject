using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float speed;

    public float jumpForce;
    
    bool touchingGround = true;

   
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (touchingGround && Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;      
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            float xMove = Input.GetAxis("Horizontal");
            Vector2 newPos = transform.position;

            newPos.x += xMove * speed * Time.deltaTime;

            Debug.Log(newPos);
            transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            float xMove = Input.GetAxis("Horizontal");
            Vector2 newPos = transform.position;

            newPos.x += xMove * speed * Time.deltaTime;

            Debug.Log(newPos);
            transform.position = newPos;
        }

    }

    private void OnCollision2D(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = false;
        }
    }

}
