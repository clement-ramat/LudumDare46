using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float cameraSpeed = 0.1f;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float highspeedThreshold = 20f;

    private ParticleSystem _ps;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the target
        MoveCamera();

        // Activate the VFX once a certain speed is reached
        if(GetTargetVelocity() > highspeedThreshold)
        {
           if(!_ps.isPlaying) _ps.Play();

        }else if(_ps.isPlaying)
        {
            _ps.Stop();
        }
    }

    private void MoveCamera()
    {
        Vector3 desiredPos = target.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, cameraSpeed * Time.deltaTime);

        transform.position = smoothPos;
    }

    private float GetTargetVelocity()
    {
        IceCubeController icc = target.GetComponent<IceCubeController>();
        if (icc != null)
        {
            return icc.GetCurrentVelocity();
        }
        
        return 0;
    }
}
