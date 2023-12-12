using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5000;
    public float gravityScale = 0.5f;
    private bool _isJumping = false;
    private bool _isJumped = false;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isOnGround)
            {
                return;
            }

            if (_isJumped)
            {
                return;
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            _isJumping = true;
            _isJumped = true;
        }

        if (_isJumping)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityScale * (1 - Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
    }

    private bool _isOnGround = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isOnGround = true;
            _isJumped = false;
        }
    }
}
