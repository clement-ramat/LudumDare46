using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;
    [SerializeField]
    private Transform d1;
    [SerializeField]
    private Transform d2;

    private float D;

    private void Start()
    {
        if (d1 != null && d2 != null)
        {
            D = Vector3.Distance(d1.position, d2.position);
        }
    }

    private void Update()
    {
        if(d1!= null && d2 != null)
        {
            progressBar.fillAmount =1.0f - Vector3.Distance(d1.position, d2.position) / D;
        }
    }
}
