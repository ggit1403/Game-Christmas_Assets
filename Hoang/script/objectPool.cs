using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objectPool : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objects;
    public List<GameObject> inactiveObjects;
    public Transform spawnPos;
    public GameObject player;
    public Transform Cam;
    public bool changePos;
    public bool OT;
    void Start()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("cloud");

        // Thêm đối tượng vào danh sách nếu chúng có tag mong muốn
        foreach (GameObject obj in allObjects)
        {
            objects.Add(obj);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pool();
        Move();
        if(player== null)
        {
            player = GameObject.FindWithTag("Player");
   
        }
       
    }

    private void Move()
    {
        float distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distanceX <= 8)
        {
            transform.position = new Vector2(transform.position.x + 8, transform.position.y);
        }
    }

    void pool()
    {
        float distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
        for (int i = 0; i < objects.Count; i++)
        {
            float distance = Mathf.Abs(player.transform.position.x - objects[i].transform.position.x);

            if (distance > 30f)
            {
                objects[i].SetActive(false);
                changePos = true;
                OT = true;
                if (objects[i].gameObject.activeSelf == false)
                {
                    if (!inactiveObjects.Contains(objects[i]))
                    {
                        inactiveObjects.Add(objects[i]);
                    }
                }

            }


        }
        if (distanceX <= 8f)
        {

            if (OT)
            {
                ActivateRandomObject(inactiveObjects);

            }

        }
    }
    void ActivateRandomObject(List<GameObject> objectsToActivate)
    {

        // Kiểm tra xem danh sách có phần tử không
        if (objectsToActivate.Count > 0)
        {

            // Chọn ngẫu nhiên một chỉ số
            int randomIndex = Random.Range(0, objectsToActivate.Count);

            // Kích hoạt đối tượng tại chỉ số được chọn
            GameObject activatedObject = objectsToActivate[randomIndex];
            activatedObject.SetActive(true);


            // Nếu cần thay đổi vị trí, hãy di chuyển nó
            if (changePos)
            {
                activatedObject.transform.position = spawnPos.position;
                changePos = false;

            }
            OT = false;
            if (activatedObject.activeSelf == true)
            {
                objectsToActivate.Remove(activatedObject);

            }


        }
    }
}
        
    






