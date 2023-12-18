using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;

        transform.Translate(movement);
    }
}