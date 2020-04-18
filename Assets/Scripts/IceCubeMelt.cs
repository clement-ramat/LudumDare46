using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeMelt : MonoBehaviour
{
    private float startScale;
    public float maxHealth = 100;

    [SerializeField]
    private float _currentHealth;
    private bool invincible = false;

    private List<Obstacle> inCollisionObstacle = new List<Obstacle>();

    public float invincibilityDuration = 5f;

    [HideInInspector]
    public float currentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if(!invincible)
            {
                _currentHealth = value;
            }
        }
    }
    private void Start()
    {
        currentHealth = maxHealth;
        startScale = transform.localScale.x;
    }

    public void Update()
    {
        if (currentHealth != 0)
        {
            float scale = currentHealth / maxHealth * startScale;
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    IEnumerator InvincibilityForSeconds(float seconds)
    {
        invincible = true;
        yield return new WaitForSeconds(seconds);
        invincible = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();


        if (obstacle != null && !inCollisionObstacle.Contains(obstacle))
        {
            inCollisionObstacle.Add(obstacle);

            currentHealth -= obstacle.damage;

            StartCoroutine(InvincibilityForSeconds(invincibilityDuration));

            if (currentHealth > 0)
            {
                //PlayCollisionVisuals();
            }
            else
            {
                //PlayDeathVisuals();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();

        if (obstacle != null && inCollisionObstacle.Contains(obstacle))
        {
            inCollisionObstacle.Remove(obstacle);
        }
    }
}
