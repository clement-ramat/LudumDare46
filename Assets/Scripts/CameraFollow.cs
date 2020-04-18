using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float cameraSpeed = 0.1f;

    [SerializeField]
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, cameraSpeed * Time.deltaTime);

        transform.position = smoothPos;
    }
}


