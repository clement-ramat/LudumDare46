using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassHitSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.gameObject.transform.position = collision.collider.transform.position;
        audioSource.Play();
    }
}
