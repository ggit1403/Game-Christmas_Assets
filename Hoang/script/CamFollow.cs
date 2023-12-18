using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector3 offset;
    public float speed = 30.0f;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * speed);


        }
        if (target == null)
        {
            Debug.Log("vl");
        }
        
    }
}