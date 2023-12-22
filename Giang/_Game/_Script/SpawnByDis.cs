using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByDis : MonoBehaviour
{

    public GameObject players;
    public float currentDis = 0f;
    public float limitDis;
    public float respawnDis ;
    public GameObject mapNext;

    private void Update()
    {

    }
    protected void FixedUpdate()
    {
        GetDistance();
        Spawning();

        if (players == null)
        {
            players = GameObject.FindWithTag("Player");
        }
    }

    protected void Spawning()
    {
        if (currentDis > limitDis )
        {
            transform.position = new Vector3(mapNext.transform.position.x + 15, transform.position.y, transform.position.z);
        }
    }

    protected virtual void GetDistance()
    {
        if(players != null)
        {
            currentDis = players.transform.position.x - transform.position.x;
        } 
    }
}

   