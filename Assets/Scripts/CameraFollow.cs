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

    [SerializeField]
    private float baseFov = 60;

    [SerializeField]
    private float highspeedFov = 70;

    [SerializeField]
    private float _fovTransitionFactor = 0.5f;

    [SerializeField]
    private Transform glassCam;

    [SerializeField]
    private ShakeCamera cameraShake;

    private float _currentFov;
    private float _fovTransition;
    private Vector3 _currentOffset;
    

    private ParticleSystem _ps;
    private Camera _c;

    private bool follow = true;
    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _c = GetComponent<Camera>();
        _currentFov = baseFov;
        _c.fieldOfView = baseFov;
        _fovTransition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            // Get current life and adjust offset (because the ice cube's size is reduced)
            float currentHealth = target.GetComponent<IceCubeMelt>().currentHealth;
            if (currentHealth <= 20) currentHealth = 20;
            _currentOffset = offset * (currentHealth * 0.01f);

            // Follow the target
            MoveCamera();

            // Activate the VFX once a certain speed is reached
            if (GetTargetVelocity() > highspeedThreshold)
            {
                if (!_ps.isPlaying && follow)
                {
                    _ps.Play();
                    cameraShake.StartShaking();
                }

                _fovTransition += Time.deltaTime * _fovTransitionFactor;
                _fovTransition = Mathf.Clamp(_fovTransition, 0.0f, 1.0f);

                _c.fieldOfView = Mathf.Lerp(baseFov, highspeedFov, _fovTransition);

            }
            else if (_ps.isPlaying || !follow)
            {
                _ps.Stop();
                cameraShake.StopShaking();

                _fovTransition -= Time.deltaTime * _fovTransitionFactor;
                _fovTransition = Mathf.Clamp(_fovTransition, 0.0f, 1.0f);

                _c.fieldOfView = Mathf.Lerp(baseFov, highspeedFov, _fovTransition);
            }
        }  
    }

    private void MoveCamera()
    {
        Vector3 desiredPos = target.transform.position + _currentOffset;
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

    public void StopFollowing()
    {
        follow = false;
        _ps.Stop();
        cameraShake.StopShaking();
    }

    public void EnableGlassView()
    {
        _c.fieldOfView = baseFov;
        transform.position = glassCam.position;
        transform.rotation = glassCam.rotation;
    }
}
