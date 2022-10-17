using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float Speed;
    public Vector2 JumpForce = new Vector2(0, 300);
    public bool CanJump = true;
    public WaterBlastBehaviour WaterBlastPrefab;

    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
     
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            waterBlastShoot();
        }

        bool shouldJump = (Input.GetKeyUp(KeyCode.Space));

        if (shouldJump && CanJump)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(JumpForce);
        }
    }

    void FixedUpdate()
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
    private void waterBlastShoot()
    {
        WaterBlastBehaviour waterblast = Instantiate(WaterBlastPrefab);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            CanJump = true;
        }
           
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            CanJump = false;
        }

    }

}
