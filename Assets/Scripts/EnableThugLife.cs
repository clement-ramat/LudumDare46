using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableThugLife : MonoBehaviour
{
    [SerializeField]
    private GameObject thugParticles;

    public void Activate()
    {
        GameObject go = Instantiate(thugParticles, transform.position, Quaternion.identity, transform);
        go.GetComponent<ParticleSystem>().Play();
        Destroy(go, go.GetComponent<ParticleSystem>().main.duration);
    }
}
