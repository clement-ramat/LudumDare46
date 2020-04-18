using UnityEngine;

public class IceCubeController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField]
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float descentSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed, 0, descentSpeed));
    }
}
