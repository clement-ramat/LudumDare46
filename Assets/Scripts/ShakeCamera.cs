using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{




    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f;
    public Camera cameraToShake;

    private bool isShaking = false;

    private void Update()
    {
        if (isShaking)
        {
            float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
            float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;

            float newCameraX = cameraShakingOffsetX + cameraToShake.transform.position.x;
            float newCameraY = cameraShakingOffsetY + cameraToShake.transform.position.y;
            cameraToShake.transform.position = new Vector3(newCameraX, newCameraY, cameraToShake.transform.position.z);
        }
    }

    public void StartShaking()
    {
        isShaking = true;
    }

    public void StopShaking()
    {
        isShaking = false;
    }

    //public void ShakeIt()
    //{
    //    cameraInitialPosition = gameObject.transform.position;
    //    InvokeRepeating("StartCameraShaking", 0f, 0.005f);
    //    Invoke("StopCameraShaking", shakeTime);

    //}

    // Update is called once per frame
    //    public void StartCameraShaking()
    //    {
    //        // float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
    //        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;

    //        Vector3 cameraIntermediatePosition = gameObject.transform.position;
    //        //cameraIntermediatePosition.x += cameraShakingOffsetX;
    //        cameraIntermediatePosition.y += cameraShakingOffsetY;
    //        gameObject.transform.position = cameraIntermediatePosition;
    //    }

    //    public void StopCameraShaking()
    //    {
    //        CancelInvoke("StartCameraShaking");
    //        gameObject.transform.position = cameraInitialPosition;
    //    }
}