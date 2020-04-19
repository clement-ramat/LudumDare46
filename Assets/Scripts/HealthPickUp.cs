using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Pickable
{
    [Header("PickUp")]
    public float health = 10;
    
    public override void Effect(GameObject player)
    {
        player.GetComponent<IceCubeMelt>().currentHealth += health;
        Destroy(gameObject);
    }
}
