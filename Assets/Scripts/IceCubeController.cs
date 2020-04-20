using UnityEngine;
using UnityEngine.SceneManagement;
public class IceCubeController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField]
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float descentSpeed = 1f;

    [SerializeField]
    private float velocityLimit = 60f;

    private float _rotAmount;
    private bool _goingLeft, _goingRight;

    private bool enableSimulation = true;

    [SerializeField]
    private HUDDataScriptableObject hudData;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rotAmount = 0;
        _goingLeft = _goingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        hudData.iceCubePosition = this.transform.position;
        if(enableSimulation)
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
            else
            {
                if (_goingLeft) _rotAmount += Time.deltaTime;
                if (_goingRight) _rotAmount -= Time.deltaTime;
            }

            // movements
            //_rb.MoveRotation(Quaternion.AngleAxis(_rotAmount * horizontalSpeed * 15, Vector3.forward));
            _rb.AddForce(new Vector3(horizontalInput * horizontalSpeed, 0, descentSpeed * Time.deltaTime));

            // Can't descend faster than that value
            LimitVelocity(velocityLimit);
        }

        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void UpdateSideVelocity(float factor)
    {
        float newSideVelocity = _rb.velocity.x * factor;
        float sideLimit = velocityLimit * 0.2f;

        if (newSideVelocity > sideLimit) newSideVelocity = sideLimit;
        if (newSideVelocity < (sideLimit * -1)) newSideVelocity = sideLimit;

        _rb.velocity = new Vector3(newSideVelocity, _rb.velocity.y, _rb.velocity.z);
    }

    public float GetCurrentVelocity()
    {
        // descent velocity, not taking into account horizontal velocity
        Vector3 v = new Vector3(0, 0 , _rb.velocity.z);
        return v.magnitude;
    }

    public void FullReset()
    {
        _rotAmount = 0;
        _goingLeft = _goingRight = false;
        _rb.velocity = Vector3.zero;
        _rb.rotation = Quaternion.identity;
    }

    public void EnableSimulation(bool b)
    {
        enableSimulation = b;
    }

    private void LimitVelocity(float limit)
    {
        float currentVelocity = GetCurrentVelocity();
        if(currentVelocity > limit)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, limit);
        }
    }

    public void BoostVelocity(float newValue)
    {
        float currentVelocity = GetCurrentVelocity();
        if (currentVelocity < newValue)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, newValue);
        }
    }

    public void UpdateFrontVelocity(float newValue)
    {
        if (newValue > velocityLimit) newValue = velocityLimit;
        _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, newValue);
    }

    public void UpdateHeightVelocity(float newValue)
    {
        if (newValue > (velocityLimit * 0.1f)) newValue = velocityLimit * 0.1f;
        _rb.velocity = new Vector3(_rb.velocity.x, newValue, _rb.velocity.z);
    }

    public void EnableGravity(bool b)
    {
        if(_rb) _rb.useGravity = b;
    }
}

