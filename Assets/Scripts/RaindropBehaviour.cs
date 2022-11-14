using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float Direction;
    public bool IsMoving;
    public static bool FaceRight;
    public AudioClip ShootSound;
    public AudioClip HitSound;
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameControllerInstance = FindObjectOfType<GameController>();
     
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

        bool shouldJump = (Input.GetKeyDown(KeyCode.Space));

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
                Direction = -1;
                FaceRight = false;
            }
            else
            {
                Direction = 1;
                FaceRight = true;
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
        Vector3 camPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(ShootSound, camPos);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            CanJump = true;
        }

        if(collision.gameObject.tag == "Lava")
        {
            CanJump = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameControllerInstance.LoseHearts--;
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(HitSound, camPos);
        }

        if (collision.gameObject.tag == "Rock")
        {
            GameControllerInstance.LoseHearts--;
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(HitSound, camPos);
        }

        if (collision.gameObject.tag == "Lava")
        {
            GameControllerInstance.LoseHearts--;
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(HitSound, camPos);
        }

        if (collision.gameObject.tag == "Door")
        {
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag == "Door2")
        {
            SceneManager.LoadScene(3);
        }

        if (collision.gameObject.tag == "Door3")
        {
            SceneManager.LoadScene(4);
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
        rb2d.velocity = new Vector2(transform.localScale.x * dashingPower * Direction, 0f);
        //player can't dash forever
        yield return new WaitForSeconds(dashingTime);
        rb2d.gravityScale = originalGravity;
        isDashing = false;
        //dashing goes on a cooldown
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
