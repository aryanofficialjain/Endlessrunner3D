using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float speedIncreaseRate = 0.5f;
    public float jumpForce = 0.1f;
    public float sideMoveSpeed = 5f;

    private float forwardSpeed;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardSpeed = baseSpeed;
    }

    void Update()
    {
    if (GameManager.Instance == null || GameManager.Instance.IsGameOver()) return;




        forwardSpeed += speedIncreaseRate * Time.deltaTime;


        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput * sideMoveSpeed, rb.velocity.y, forwardSpeed);
        rb.velocity = moveDirection;

        // Jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Obstacle"))

    {   CameraShake.Instance.Shake(0.4f, 0.25f);
        
    }
}
}