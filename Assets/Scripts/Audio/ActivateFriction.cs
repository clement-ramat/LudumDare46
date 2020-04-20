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

    [SerializeField]
    private float maxVelocity = 10f;

    private bool isColliding = false;

    private int nbColliding = 0;

    [SerializeField]
    private float cooldown = 0.1f;

    private bool isCoolingDown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (rbToTrack.velocity.magnitude > velocityThreshold && isColliding)
        //{
        //    //audioSource.volume = 1;
        //    //audioSource.volume = rbToTrack.velocity.magnitude / maxVelocity + velocityThreshold;
            
        //    audioSource.volume = Mathf.InverseLerp(velocityThreshold, maxVelocity, rbToTrack.velocity.magnitude);
        //} else
        //{
        //    audioSource.volume = 0;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isCoolingDown)
        {
            Debug.Log("cooldown en cours");            
            audioSource.Play();
            Cooldown(cooldown);
        }
        
        
        nbColliding++;
        UpdateColliding();
    }

    private void OnTriggerExit(Collider other)
    {
        nbColliding--;
        UpdateColliding();
    }

    private void UpdateColliding()
    {
        if (nbColliding > 0)
        {       
            isColliding = true;
        } else
        {
            isColliding = false;
        }
    }

    IEnumerator Cooldown(float cooldown)
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldown);
        isCoolingDown = false;
        Debug.Log("plus de cooldown");
    }
}
