using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int   HP ;
    public int score;
    public float moveSpeed; // toc do di chuyen den goc man hinh
    public GameObject pos;
    Rigidbody2D rb;

   
    
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if(pos == null)
        {
            pos = GameObject.FindWithTag("pos"); 
        }
        


    }
    IEnumerator SwitchMap(float timeWait ,string nameMap)
    {
        SceneManager.LoadScene(nameMap, LoadSceneMode.Single);
        yield return new WaitForSeconds(timeWait);
        if(rb != null)
        {
            this.gameObject.transform.position = pos.transform.position;
        }
       


    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            HP -= 1;
        }
        else if (other.gameObject.CompareTag("items"))
        {
            score += 1;
        }
        else if (other.gameObject.CompareTag("switchPos"))
        { 
            StartCoroutine(SwitchMap(0.2f,"onSky"));
            

        }
        else if (other.gameObject.CompareTag("switchZone"))
        {
            StartCoroutine(SwitchMap(0.2f, "onGround"));  // va cham voi diem chuyen Map

        }

    }
   

}
