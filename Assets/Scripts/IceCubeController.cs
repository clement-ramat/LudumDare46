using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float baseSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        _controller.Move(movement * Time.deltaTime * baseSpeed);
    }
}
