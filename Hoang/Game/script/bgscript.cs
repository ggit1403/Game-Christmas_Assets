using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Renderer bgRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        transform.position= new Vector3 (transform.position.x, transform.position.y, 1);
    }
}
