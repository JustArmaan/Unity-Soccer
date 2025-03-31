using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpHeight = 5f; // Height of the jump
    public LayerMask groundLayer; // Ground detection layer

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f, groundLayer);

        // Move the cube (left, right, forward, backward)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float moveZ = Input.GetAxis("Vertical"); // W/S or Up/Down arrow

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Jump if grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
