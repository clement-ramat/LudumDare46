﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeMelt : MonoBehaviour
{
    private float maxScale;
    public float minimumScale = 20;

    public float maxHealth = 100;

    [SerializeField]
    private float _currentHealth;
    private bool invincible = false;

    private List<Obstacle> inCollisionObstacle = new List<Obstacle>();
    [HideInInspector]
    public List<MeltingZone> meltingZones = new List<MeltingZone>();
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
            if (value < 0)
            {
                if (!invincible)
                {
                    _currentHealth = value;
                }
            }
            else
            {
                if(value > maxHealth)
                {
                    _currentHealth = maxHealth;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
    }
    private void Start()
    {
        currentHealth = maxHealth;
        maxScale = transform.localScale.x - minimumScale;
    }

    public void Update()
    {
        foreach (MeltingZone meltingZone in meltingZones)
        {
            currentHealth -= meltingZone.damagePerSeconds * Time.deltaTime;
        }

        if (currentHealth != 0)
        {
            float scale = minimumScale + (currentHealth / maxHealth * maxScale);
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
