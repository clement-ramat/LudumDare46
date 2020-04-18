using UnityEngine;

public class IceCubeController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField]
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float descentSpeed = 1f;

    private float _rotAmount;
    private bool _goingLeft, _goingRight;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rotAmount = 0;
        _goingLeft = _goingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // barrel roll
        // Going to the left
        if (horizontalInput < 0)
        {
            _rotAmount += Time.deltaTime;

            // if changing direction
            if (_goingRight) UpdateSideVelocity(0.2f);
            
            _goingLeft = true;
            _goingRight = false;
        }

        // Going to the right
        else if (horizontalInput > 0)
        {
            _rotAmount -= Time.deltaTime;

            // if changing direction
            if (_goingLeft) UpdateSideVelocity(0.2f);

            _goingLeft = false;
            _goingRight = true;
        }

        // movements
        _rb.MoveRotation(Quaternion.AngleAxis(_rotAmount * horizontalSpeed * 30, Vector3.forward));
        _rb.AddForce(new Vector3(horizontalInput * horizontalSpeed, 0, descentSpeed));   
    }

    private void UpdateSideVelocity(float factor)
    {
        _rb.velocity = new Vector3(_rb.velocity.x * factor, _rb.velocity.y, _rb.velocity.z);
    }

    public float GetCurrentVelocity()
    {
        // descent velocity, not taking into account horizontal velocity
        Vector3 v = new Vector3(0, 0 , _rb.velocity.z);
        return v.magnitude;

        //return _rb.velocity.magnitude;
    }
}

