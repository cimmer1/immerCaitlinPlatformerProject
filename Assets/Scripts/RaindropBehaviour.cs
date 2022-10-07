using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool isJumping;   
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
     
    }

    private void Update()
    {
        bool isJumping = (Input.GetKeyUp(KeyCode.Space));

        if (isJumping)
        {
            rb2d.velocity = Vector2.zero;
            jumpForce = 4f;
           
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }

    }

}
