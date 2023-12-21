using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RootCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    GameObject cam;
    public float distance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        else
        {
            distance = Mathf.Abs(cam.transform.position.x - transform.position.x);

            if (distance > 30f)
            {
                rb.velocity = Vector2.left * -speed * Time.fixedDeltaTime;

            }
            else
            {
                rb.velocity = Vector2.left * speed * Time.fixedDeltaTime;
            }
        }

    }
}
