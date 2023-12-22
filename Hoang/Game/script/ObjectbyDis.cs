using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectbyDis : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cam;
    public float limitdis;
    void Start()
        
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        else
        {
            float disX = Mathf.Abs(cam.transform.position.x-transform.position.x);
            if (disX>limitdis)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
