using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour
{
    [SerializeField]
    private SpawnManagerScriptableObject spawnData;

    [SerializeField]
    private string tagToCheck = "Player";

    void Awake()
    {
        if (spawnData == null)
        {
            Debug.LogError("Spawn Data hasn't been specified");
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToCheck)
        {
            // TODO
        }
    }
}
