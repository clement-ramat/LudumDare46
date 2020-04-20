using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenIceExplosion : MonoBehaviour
{
    public float forceStrength;

    public List<GameObject> parts;

    private void OnEnable()
    {
        Explode();
    }
    public void Explode(float multiplier = 1)
    {
        foreach(GameObject part in parts)
        {
            part.GetComponent<Rigidbody>().AddExplosionForce(forceStrength * multiplier, transform.position + new Vector3(0,0,0.5f), 5);
            StartCoroutine(BecomeNonCollidableAfterSeconds(3));
        }
    }



    IEnumerator BecomeNonCollidableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        foreach (GameObject part in parts)
        {
            part.GetComponent<Rigidbody>().isKinematic = true;
            part.GetComponent<Collider>().enabled = false;
        }
    }
}
