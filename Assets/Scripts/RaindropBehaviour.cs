using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float speed;
    //public float jumpForce;
    public Vector2 jumpForce = new Vector2(0, 300);

    public bool canJump = true; 
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
     
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
        bool shouldJump = (Input.GetKeyUp(KeyCode.Space));

        if (shouldJump && canJump)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(jumpForce);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            canJump = true;
        }
           
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            canJump = false;
        }

    }

}
