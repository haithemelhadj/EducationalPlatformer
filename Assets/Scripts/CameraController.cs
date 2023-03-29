using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;
    public float maxDistance = 10f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        // Check if the camera is too close to the player
        float distance = Vector3.Distance(smoothedPosition, target.position);
        if (distance > maxDistance)
        {
            smoothedPosition = target.position + (smoothedPosition - target.position).normalized * maxDistance;
            velocity = Vector3.zero;
        }

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}