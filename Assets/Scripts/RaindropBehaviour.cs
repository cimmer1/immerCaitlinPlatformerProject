using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float speed;
    //public float jumpForce;
    public Vector2 jumpForce = new Vector2(0, 300);

    private bool isJumping = false;   
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
     
    }

    private void Update()
    {
        bool isJumping = (Input.GetKeyUp(KeyCode.Space));

        if (isJumping == true)
        {
            rb2d.velocity = Vector2.zero;
            //jumpForce = 4f;
            rb2d.AddForce(jumpForce);

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
            isJumping = true;
        }
           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

    }

}
