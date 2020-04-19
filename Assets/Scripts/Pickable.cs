using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [Header("Animation")]
    public float verticalSpeed = 0.8f;
    public float verticalOffset = 0.33f;
    public float angularVelocity = 50;
    private float startY;

    private bool goingUp = true;

    private void Start()
    {
        startY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Effect(other.gameObject);
        }
    }

    public virtual void Effect(GameObject player)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, angularVelocity * Time.deltaTime, 0);
        float adaptedSpeed = verticalSpeed * Mathf.Abs(Mathf.Cos(((transform.position.y - startY) /  (verticalOffset * 1.1f)) * Mathf.PI/2));

        if((adaptedSpeed) < 0.05f)
        {
           adaptedSpeed = 0.05f;
        }

        transform.position += (goingUp ? 1 : -1) * new Vector3(0, adaptedSpeed * Time.deltaTime, 0);

        if(goingUp && transform.position.y >= startY + verticalOffset)
        {
            goingUp = false;
        }
        else if (!goingUp && transform.position.y <= startY - verticalOffset)
        {
            goingUp = true;
        }
    }
}