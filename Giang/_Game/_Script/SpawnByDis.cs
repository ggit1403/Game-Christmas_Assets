using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByDis : MonoBehaviour
{

    public GameObject players;
    public float currentDis = 0f;
    public float limitDis;
    public float respawnDis;
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
<<<<<<< HEAD
            transform.position = new Vector3(mapNext.transform.position.x + 15, transform.position.y, transform.position.z);
=======
            transform.position = new Vector3(mapNext.transform.position.x + respawnDis, transform.position.y, transform.position.z);
>>>>>>> 82b27060062294d10d370d1161be31f9ca2a3f80
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

   