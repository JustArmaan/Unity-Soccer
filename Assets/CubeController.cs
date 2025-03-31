using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float kickForce = 10f;
    public float kickDistance = 2f; 
    public float dribbleOffset = 1.5f; 
    
    private Rigidbody rb;
    private bool isGrounded;
    
    private Transform cameraTransform;
    private GameObject currentBall;
    private bool isDribbling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 
        
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleBallInteraction();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D keys or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W/S keys or Up/Down arrows

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0; 
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camRight * moveX) + (camForward * moveZ);

        Vector3 targetVelocity = moveDirection * moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;  
        rb.linearVelocity = targetVelocity;

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }

    private void HandleBallInteraction()
    {
        if (currentBall == null)
        {
            currentBall = GameObject.FindGameObjectWithTag("Ball");
        }

        if (currentBall != null)
        {
            float distanceToBall = Vector3.Distance(transform.position, currentBall.transform.position);
            
            if (Input.GetMouseButtonDown(0) && distanceToBall <= kickDistance)
            {
                Rigidbody ballRb = currentBall.GetComponent<Rigidbody>();
                
                if (ballRb != null)
                {
                    isDribbling = true;
                    ballRb.isKinematic = true; 
                }
            }
            
            if (isDribbling)
            {
                Rigidbody ballRb = currentBall.GetComponent<Rigidbody>();
                
                if (ballRb != null)
                {
                    Vector3 dribblePosition = transform.position + transform.forward * dribbleOffset;
                    
                    currentBall.transform.position = dribblePosition;
                    currentBall.transform.rotation = transform.rotation;
                }
            }
            
            // Changed to right mouse button (Input.GetMouseButtonDown(1))
            if (Input.GetMouseButtonDown(1))
            {
                Rigidbody ballRb = currentBall.GetComponent<Rigidbody>();
                
                if (ballRb != null && isDribbling)
                {
                    ballRb.isKinematic = false;
                    
                    Vector3 kickDirection = transform.forward;
                    ballRb.AddForce(kickDirection * kickForce, ForceMode.Impulse);
                    
                    isDribbling = false;
                }
            }
            
            if (isDribbling && Vector3.Distance(transform.position, currentBall.transform.position) > kickDistance)
            {
                currentBall.GetComponent<Rigidbody>().isKinematic = false;
                isDribbling = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}