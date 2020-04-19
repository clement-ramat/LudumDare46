using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
}

public class HealthPickUp : Pickable
{
    public float health = 10;

    private void OnTriggerEnter(Collider other)
    {
        IceCubeMelt icm = other.GetComponent<IceCubeMelt>();

        if (icm != null)
        {
            icm.currentHealth += health;
        }

        PlayPickedUp();
    }

    private void PlayPickedUp()
    {
        Destroy(gameObject);
    }
}