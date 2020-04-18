using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private SpawnManagerScriptableObject spawnData;

    void Awake()
    {
        if (spawnData == null)
        {
            Debug.LogError("Spawn Data hasn't been specified");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            spawnData.ResetCubePosition();
        }
    }

    
}
