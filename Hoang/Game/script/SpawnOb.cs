using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOb : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public List<GameObject> obs;
    public GameObject ob;
    public List<GameObject> inactiveObjects;
    public float time = 0;
    public float timer;
    public bool full =false;
    public int num;
    public int min;
    public int max;
    public int minY;
    public int maxY;
    void Start()
    {
        obs = new List<GameObject>(10);
        time = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
       
    }
    private void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        GetPool(ob, obs, num);
        if (time < 0 )
        {
            time = timer;
            if (inactiveObjects != null)
            {
                pool(obs);
            }
        }

    }
    protected Vector2 GetPos()
    {
        int rdY = Random.Range(minY, maxY);
        Vector2 pos = new Vector2(player.transform.position.x + 20, rdY);
        return pos;
    }
    protected void GetPool(GameObject ob, List<GameObject> obs,int n)
    {
        if(obs.Count < n) {
            full = false;
            for (int i = 0; i < n; i++)
            {
                if(!full)
                {
                    GameObject Emtp = Instantiate(ob);
                    Emtp.SetActive(false);
                    obs.Add(Emtp);
                    
                }
            }
        }
        else
        {
            full = true;
        }
        
        
        if (inactiveObjects.Count < obs.Count) {
         
            for (int i = 0; i< obs.Count;i++)
            {
                if (obs[i].activeSelf == false)
                {
                    if (!inactiveObjects.Contains(obs[i]))
                    {
                        inactiveObjects.Add(obs[i]);
                    }
                }
            }
        }
    }
    protected void pool(List<GameObject> obs)
    {
         if(obs != null) { 
            int quantity = Random.Range(min, max);
            for (int i = 0; i < quantity; i++)
             {
                int rdIndex = Random.Range(0, inactiveObjects.Count);
                inactiveObjects[rdIndex].SetActive(true);
                inactiveObjects[rdIndex].transform.position = GetPos();
                inactiveObjects.Remove(inactiveObjects[rdIndex]);
            }
         }
    }
   
}



