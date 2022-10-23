using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RaindropBehaviour : MonoBehaviour
{
    public float Speed;
    public Vector2 JumpForce = new Vector2(0, 300);
    public GameObject SpawnPoint;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 2f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 4f;

    public bool CanJump = true;

    public GameController GameControllerInstance;
    public WaterBlastBehaviour WaterBlastPrefab;

    private Rigidbody2D rb2d;
    public float direction;
    public bool IsMoving;
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
     
    }

    private void Update()
    {
        //prevents player from moving/jumping while dashing 
        if (isDashing)
        {
            return;
        }

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            if(Input.GetAxis("Horizontal") < 0)
            {
                direction = -1; 
            }
            else
            {
                direction = 1;
            }
            IsMoving = true; 
        }
        else
        {
            IsMoving = false; 
        }
       }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (IsMoving)
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
        WaterBlastBehaviour waterblast = Instantiate(WaterBlastPrefab, SpawnPoint.transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            CanJump = true;
        }

        if (collision.gameObject.tag == "Mushroom")
        {
            GameControllerInstance.LoseHearts--;
        }

        if (collision.gameObject.tag == "Rock")
        {
            GameControllerInstance.LoseHearts--;
        }
           
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            CanJump = false;
        }


    }
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0f;
        //transform.localscale.x indicates the direction the player is facing 
        rb2d.velocity = new Vector2(transform.localScale.x * dashingPower * direction, 0f);
        //player can't dash forever
        yield return new WaitForSeconds(dashingTime);
        rb2d.gravityScale = originalGravity;
        isDashing = false;
        //dashing goes on a cooldown
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
