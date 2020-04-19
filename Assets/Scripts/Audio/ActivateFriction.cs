using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFriction : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Rigidbody rbToTrack;

    [SerializeField]
    private float velocityThreshold = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rbToTrack.velocity.magnitude > velocityThreshold)
        {
            audioSource.volume = 1;
        } else
        {
            audioSource.volume = 0;
        }
    }
}
