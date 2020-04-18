using UnityEngine;

public class IceCubeController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField]
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float descentSpeed = 1f;

    private float rot;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        _rb.AddForce(new Vector3(horizontalInput * horizontalSpeed, 0, descentSpeed));

        rot += Time.deltaTime;

        if(horizontalInput < 0) _rb.MoveRotation(Quaternion.AngleAxis(180 * rot, Vector3.forward));
        else if(horizontalInput > 0) _rb.MoveRotation(Quaternion.AngleAxis(180 * rot * -1, Vector3.forward));


    }

    public float GetCurrentVelocity()
    {
        // descent velocity, not taking into account horizontal velocity
        Vector3 v = new Vector3(0, 0 , _rb.velocity.z);
        return v.magnitude;

        //return _rb.velocity.magnitude;
    }
}

