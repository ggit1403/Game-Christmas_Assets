using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPos : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public float dis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = new Vector2(player.transform.position.x +dis,0);
        else
        {
            player = GameObject.FindWithTag("Player");
          
        }
    }
}
