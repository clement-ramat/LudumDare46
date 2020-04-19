using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [Header("Animation")]
    public float verticalSpeed;
    public float verticalOffset;
    public float angularVelocity;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Effect(other.gameObject);
        }
    }

    public void Effect(GameObject player)
    {
        Destroy(gameObject);
    }
}