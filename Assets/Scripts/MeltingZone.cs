using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingZone : MonoBehaviour
{
    public float damagePerSeconds;

    private void OnTriggerEnter(Collider other)
    {
        IceCubeMelt icm = other.GetComponent<IceCubeMelt>();
        if (icm != null && !icm.meltingZones.Contains(this))
        {
            icm.meltingZones.Add(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IceCubeMelt icm = other.GetComponent<IceCubeMelt>();

        if (icm != null && icm.meltingZones.Contains(this))
        {
            icm.meltingZones.Remove(this);
        }
    }
}
