using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IceCubeController icc = other.GetComponent<IceCubeController>();

        if(icc != null)
        {
            icc.FullReset();
            icc.EnableSimulation(false);

            other.GetComponent<EnableThugLife>().Activate();
        }
    }
}
