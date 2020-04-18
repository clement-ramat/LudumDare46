using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    private GameObject playerObject;

    private GameObject currentSpawn;

    public string playerObjectTag = "Player";

    public string spawnObjectTag = "Spawn";

    public GameObject GetPlayerObject()
    {
        if (playerObject != null)
        {
            return playerObject;
        }

        playerObject = GameObject.FindGameObjectWithTag(playerObjectTag);

        return playerObject;
    }

    public GameObject GetCurrentSpawn()
    {
        if (currentSpawn != null)
        {
            return currentSpawn;
        }

        currentSpawn = GameObject.FindGameObjectWithTag(spawnObjectTag);

        return currentSpawn;
    }

    public void ResetCubePosition()
    {
        GameObject playerObject = GetPlayerObject();

        //playerObject.GetComponent<IceCubeController>().Reset();

        playerObject.transform.position = GetCurrentSpawn().transform.position;

    }

    //public T Get<T>
}
