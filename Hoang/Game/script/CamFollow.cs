using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f; // Điều chỉnh độ mượt của việc theo dõi
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            // Lấy vị trí hiện tại của camera
            Vector3 desiredPosition = new Vector3(target.transform.position.x+4 , transform.position.y, transform.position.z);

            // Tính toán vị trí mục tiêu mà camera sẽ di chuyển đến
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Di chuyển camera đến vị trí mới
            transform.position = smoothedPosition;
        }
        
        
    }
}