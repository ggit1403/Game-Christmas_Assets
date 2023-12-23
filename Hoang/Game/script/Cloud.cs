using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    GameObject cam;
    public float distance;
    public GameObject startPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
<<<<<<< HEAD
    
=======
>>>>>>> 82b27060062294d10d370d1161be31f9ca2a3f80
    private void Update()
    {
         if(startPos == null)
        {
            startPos = GameObject.FindWithTag("startPos");
        }
    }
<<<<<<< HEAD
    
=======

>>>>>>> 82b27060062294d10d370d1161be31f9ca2a3f80
    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = Vector2.left * speed * Time.fixedDeltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("endPos")) {
            transform.position = startPos.transform.position;
        }
    }
}

   
