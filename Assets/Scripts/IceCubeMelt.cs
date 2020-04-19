using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IceCubeMelt : MonoBehaviour
{
    private float maxScale;
    public float minimumScale = 0.2f;

    public float maxHealth = 100;

    [SerializeField]
    private float _currentHealth;
    private bool invincible = false;

    private List<Obstacle> inCollisionObstacle = new List<Obstacle>();
    [HideInInspector]
    public List<MeltingZone> meltingZones = new List<MeltingZone>();
    public float invincibilityDuration = 5f;

    [SerializeField]
    private GameObject collisionParticles;


    private IceCubeController _icc;

    public UnityEvent OnCollision;


    [HideInInspector]
    public float currentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if (value < _currentHealth)
            {
                if (!invincible)
                {
                    Debug.Log("took damage");

                    _currentHealth = value;
                }
                else
                {
                    Debug.Log("took damage but invincible");
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
        _icc = GetComponent<IceCubeController>();
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
            Debug.Log("collision");
            inCollisionObstacle.Add(obstacle);

            currentHealth -= obstacle.damage;

            OnCollision?.Invoke();

            StartCoroutine(InvincibilityForSeconds(invincibilityDuration));

            BumpPlayer();

            if (currentHealth > 0)
            {
                PlayCollisionVisuals();
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

    private void PlayCollisionVisuals()
    {
        if (collisionParticles != null)
        {
            GameObject go = Instantiate(collisionParticles, transform.position, Quaternion.identity, transform);
            go.GetComponent<ParticleSystem>().Play();
            Destroy(go, 1);
        }
    }

    private void BumpPlayer()
    {
        //float currentVelocity = _icc.GetCurrentVelocity();
        _icc.UpdateSideVelocity(-2f);
    }


}
