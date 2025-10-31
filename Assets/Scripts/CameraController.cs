using UnityEngine;

public class IsometricCameraFollowUpOnly : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;

    private Vector3 isometricUp = new Vector3(1f, 0f, 1f).normalized;

    private float highestProgress; 
    private Vector3 fixedPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("CameraFollow: Player not assigned.");
            enabled = false;
            return;
        }

        fixedPosition = transform.position;

        highestProgress = Vector3.Dot(player.position, isometricUp);
    }

    void LateUpdate()
    {
        float playerProgress = Vector3.Dot(player.position, isometricUp);

        if (playerProgress > highestProgress)
        {
            highestProgress = playerProgress;

            Vector3 movement = isometricUp * (highestProgress - Vector3.Dot(fixedPosition, isometricUp));
            Vector3 targetPosition = fixedPosition + movement;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
