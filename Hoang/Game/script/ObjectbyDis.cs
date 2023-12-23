using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectbyDis : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cam;
<<<<<<< HEAD
    public float limitdis;
    void Start()
        
=======
    void Start()
>>>>>>> 82b27060062294d10d370d1161be31f9ca2a3f80
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
<<<<<<< HEAD
            if (disX>limitdis)
=======
            if (disX>15)
>>>>>>> 82b27060062294d10d370d1161be31f9ca2a3f80
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
