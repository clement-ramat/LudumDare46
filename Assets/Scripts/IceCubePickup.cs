using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubePickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupParticles;

    private bool isPlaying = false;

    public void PlayEffect()
    {
        if(!isPlaying)
        {
            GameObject go = Instantiate(pickupParticles, transform.position, Quaternion.identity, transform);

            StartCoroutine(Cooldown(go.GetComponent<ParticleSystem>().main.duration));
            
            go.GetComponent<ParticleSystem>().Play();
            Destroy(go, go.GetComponent<ParticleSystem>().main.duration);
        }
    }

    IEnumerator Cooldown(float seconds)
    {
        isPlaying = true;
        yield return new WaitForSeconds(seconds);
        isPlaying = false;
    }
}
