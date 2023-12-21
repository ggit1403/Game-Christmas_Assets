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
    float lerpedValue =3;
 
 
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
        if(obPool != null)
        {
            if (transform.position.y < obPool.transform.position.y)
            {
                switchZone.GetComponent<CamFollow>().enabled = false;

            }
        }

    }
    void FixedUpdate()
    {
        
        if (rb != null && canjump)
        {
            cam.GetComponent<CamFollow>().offset = new Vector3(5.5f,3f,-10);
            Bg.GetComponent<CamFollow>().offset = new Vector3(8, 5f,0);
            rb.velocity = Vector2.right * speed * Time.fixedDeltaTime;
            cam.GetComponent<CamFollow>().speed = 25;
            Bg.GetComponent<CamFollow>().speed = 25f;
            if (Input.GetKey(KeyCode.Space))
            {
              rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
     
  
        if (rb != null && !canjump ){
            cam.GetComponent<CamFollow>().offset =new Vector3(5.5f,-3.5f,-10);
            Bg.GetComponent<CamFollow>().offset = new Vector3(8, 1, 0);
        
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
            if ( rb.velocity.y < 0)
            {
                cam.GetComponent<CamFollow>().speed = 0.8f;
                Bg.GetComponent<CamFollow>().speed = 0.8f;
             
            }
        }
        
        if (switchMap)
        {

            rb.gravityScale = 0;
            Bg.GetComponent<CamFollow>().enabled = false;
            cam.GetComponent<CamFollow>().enabled = false;
            
        }

   


      
    }
    float CamVertical()
    {
       lerpedValue += 1 * Time.fixedDeltaTime;

        // Đảm bảo setUp không bao giờ nhỏ hơn -3
         lerpedValue = Mathf.Min(lerpedValue,3);
        return lerpedValue;
    }

  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud")|| collision.gameObject.CompareTag("Ground"))
        {
            canjump = true;
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud") || collision.gameObject.CompareTag("Ground"))
        {
            canjump = false;
            
        }
    }
   
     
  
}
   
