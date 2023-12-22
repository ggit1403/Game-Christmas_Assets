using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusOb : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public List<GameObject> listOb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            for(int i = 0; i < listOb.Count; i++) {
                listOb[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < listOb.Count; i++)
            {
                listOb[i].SetActive(false);
            }
        }
        
    }
}
