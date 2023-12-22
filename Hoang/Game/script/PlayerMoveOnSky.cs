using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMoveOnSky : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    public float force;
    public bool canjump ;
    public bool switchMap;

 
    public GameObject Bg;
    public GameObject cam;
    public GameObject switchZone;
    public GameObject obPool;
    float currentTime;

 
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canjump = false;
        
    }

    private void Update()
    {
    
       if(cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        if (Bg == null)
        {
            Bg = GameObject.FindWithTag("backGround");
        }
        if (switchZone == null)
        {
            switchZone = GameObject.FindWithTag("switchZone");

        }
        if (obPool == null)
        {
            obPool = GameObject.FindWithTag("obPool");
        }
        /*
        if(obPool != null)
        {
            if (transform.position.y < obPool.transform.position.y)
            {
                switchZone.GetComponent<CamFollow>().enabled = false;

            }
        }
        */
    }
    void FixedUpdate()
    {
        
        if (rb != null && canjump)
        {
           
            rb.velocity = Vector2.right * speed * Time.fixedDeltaTime;
           
            if (Input.GetKey(KeyCode.Space))
            {
              rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
     
  
        if (rb != null && !canjump ){
        
        
            if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y < 0)
            {
                rb.gravityScale = 0.1f; // nhan A de giam toc do roi
                
            }           
            else
            {
                if (!switchMap)
                {
                    rb.gravityScale = 1f;
                }
            }
           
        }
    }


  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud"))
        {
            canjump = true;
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud") )
        {
            canjump = false;
            
        }
    }
   
     
  
}
   
