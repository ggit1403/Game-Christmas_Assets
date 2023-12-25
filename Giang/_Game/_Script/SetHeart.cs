
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class SetHeart : MonoBehaviour
{

    // Start is called before the first frame update
    public int NumOfHearts;
    public int Hp;
    public UnityEngine.UI.Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    public GameObject  gameOver;

    void Start()
    {

       
    }
    private void Awake()
    {
       /* gameOver.gameObject.SetActive(false);*/
    }
    // Update is called once per frame
    void Update()
    {

        // Đảm bảo Hp không vượt quá NumOfHearts
        if (Hp > NumOfHearts)
        {
            Hp = NumOfHearts;
        }

        // Đảm bảo Hp không dưới 0
        else if (Hp == 0)
        {
            Hp = NumOfHearts;
            gameOver.gameObject.SetActive(true);


        }
       
     
        // Đảm bảo số lượng fullHearts bằng giá trị của Hp
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Hp)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            Hp -= 1;
        }
    }
}
