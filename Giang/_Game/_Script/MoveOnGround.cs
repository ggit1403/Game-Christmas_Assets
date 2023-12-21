using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoveOnGround : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public float jumpForce = 5000;
    public float gravityScale;
   /* private bool _isJumping = false;*/
    private bool _isJumped = false;
    private bool _isOnGround = false;
    public bool moving = true;
    public bool switchMap = false;
   
  
    Rigidbody2D rb;
    void Start()
    {
        moving = true;
        switchMap = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float moveSpeed = 5f;

    void FixedUpdate()
    {
        
           if (switchMap)
            {
            // Tính toán vectơ di chuyển dựa trên Vector2.up và tốc độ di chuyển
            Vector3 moveDirection = Vector2.up * moveSpeed * Time.deltaTime;

            // Di chuyển đối tượng lên trên theo vectơ di chuyển
            transform.Translate(moveDirection);

            rb.gravityScale = 0;
      
             
            }
            else
            {
                rb.gravityScale = 1;
            }
        
        

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(moving) {
            Vector3 movement = new Vector3(0f, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
            transform.Translate(movement);
            transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
        }
      

        

        if (Input.GetKey(KeyCode.Space))
        {
            if (!_isOnGround)
            {
                return;
            }

            if (_isJumped)
            {
                return;
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

           /* _isJumping = true;*/
            _isJumped = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isOnGround = true;
            _isJumped = false;
           
        }
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D other )
    {
        if (other.gameObject.CompareTag("reindeer"))
        {

            switchMap = true;
            moving = false;
            
           
            
        }
        else if (other.gameObject.CompareTag("switchZone"))
        {

            switchMap = false;
            moving = true;

        }
    }
  


}
