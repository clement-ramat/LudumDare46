using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnManager", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    private GameObject playerObject;

    private GameObject currentSpawn;

    private GameObject currentCamera;

    public string playerObjectTag = "Player";

    public string spawnObjectTag = "Spawn";

    public string cameraTag = "MainCamera";


    public GameObject GetDataObject(ref GameObject data, string tag)
    {
        if (data != null)
        {
            Debug.Log("data not null data is " + data);
            return data;
        }

        data = GameObject.FindGameObjectWithTag(tag);
        Debug.Log("data was null now data is " + data);

        return data;
    }

    public GameObject PlayerObject
    {
        get
        {
            return GetDataObject(ref playerObject, playerObjectTag);
        }

        set
        {
            playerObject = value;
        }
    }

    public GameObject CurrentSpawn
    {
        get
        {
            return GetDataObject(ref currentSpawn, spawnObjectTag);
        }

        set
        {
            currentSpawn = value;
        }
    }

    public GameObject CurrentCamera
    {
        get
        {
            return GetDataObject(ref currentCamera, cameraTag);
        }

        set
        {
            currentCamera = value;
        }
    }


    public void ResetCubePosition()
    {
        GameObject playerObject = PlayerObject;
        playerObject.SetActive(true);

        //playerObject.GetComponent<IceCubeController>().Reset();
        playerObject.transform.position = CurrentSpawn.transform.position;
        playerObject.GetComponent<IceCubeMelt>().Reset();
        playerObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        playerObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        playerObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

    }

    public void ResetData()
    {
        PlayerObject = null;

        CurrentSpawn = null;

        CurrentCamera = null;
    }



    //public T Get<T>
}
