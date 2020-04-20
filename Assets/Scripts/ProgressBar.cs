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
        if (hudData.spawnTransform != null && hudData.goalTransform != null)
        {
            D = Vector3.Distance(hudData.spawnTransform.position, hudData.goalTransform.position);
        }
    }

    private void Update()
    {
        if(hudData.spawnTransform != null && hudData.goalTransform != null)
        {
            progressBar.fillAmount =1.0f - Vector3.Distance(hudData.spawnTransform.position, hudData.goalTransform.position) / D;
        }
    }
}
