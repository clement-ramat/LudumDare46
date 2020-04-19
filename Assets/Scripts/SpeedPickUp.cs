using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : Pickable
{
    // 50% bonus velocity
    [Header("PickUp")]
    public float bonus = 1.5f;
    
    public override void Effect(GameObject player)
    {
        float newVelocity = player.GetComponent<IceCubeController>().GetCurrentVelocity() * bonus;
        player.GetComponent<IceCubeController>().BoostVelocity(newVelocity);
        Destroy(gameObject);
    }
}
