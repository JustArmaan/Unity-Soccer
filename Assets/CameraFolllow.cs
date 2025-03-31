using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-2, 400, -400); 
    public float smoothSpeed = 0.125f;
    public float rotationSmooth = 0.1f;
    public float lookAheadDistance = 5f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // If no target is assigned, try to find the player cube
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 targetVelocity = Vector3.zero;
        Rigidbody targetRb = target.GetComponent<Rigidbody>();
        if (targetRb != null)
        {
            targetVelocity = targetRb.linearVelocity;
            targetVelocity.y = 0;
        }
        
        Vector3 lookAheadPos = target.position + targetVelocity.normalized * lookAheadDistance * (targetVelocity.magnitude / 5f);
        
        Vector3 desiredPosition = target.position + offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        
        Vector3 lookAtPos = Vector3.Lerp(target.position, lookAheadPos, targetVelocity.magnitude > 0.1f ? 1 : 0);
        
        Quaternion targetRotation = Quaternion.LookRotation(lookAtPos - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmooth);
    }
}