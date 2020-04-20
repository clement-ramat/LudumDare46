using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;
    //[SerializeField]
    //private Transform d1;
    //[SerializeField]
    //private Transform d2;

    [SerializeField]
    private HUDDataScriptableObject hudData;

    private float D;

    private void Start()
    {
        if (hudData.spawnPosition != null && hudData.goalPosition != null)
        {
            D = Vector3.Distance(hudData.spawnPosition, hudData.goalPosition);
            Debug.Log(D);
        }
    }

    private void Update()
    {
        if(hudData.spawnPosition != null && hudData.goalPosition != null)
        {
            Debug.Log(1.0f - Vector3.Distance(hudData.iceCubePosition, hudData.goalPosition) / D);
            progressBar.fillAmount = 1.0f - Vector3.Distance(hudData.iceCubePosition, hudData.goalPosition) / D;
        }
    }
}
