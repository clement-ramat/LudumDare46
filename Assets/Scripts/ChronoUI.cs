using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChronoUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    private float seconds, minutes;

    private bool isRunning = true;
    private bool ok = false;

    private Coroutine mCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        mCoroutine = StartCoroutine("secondCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning && ok)
        {
            if(seconds >= 60f)
            {
                minutes = (int)(seconds / 60f);
                seconds = (int)(seconds % 60);
            }
            mCoroutine = StartCoroutine("secondCoroutine");
        }
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }



    public void ResetChrono(bool stillRunning)
    {
        counterText.alpha = 1;
        StopCoroutine(mCoroutine);
        minutes = 0f;
        seconds = 0f;
        isRunning = stillRunning;
        ok = true;
    }

    
    public void PauseChrono()
    {
        StopCoroutine(mCoroutine);
        isRunning = false;
    }

    
    public void ResumeChrono()
    {
        isRunning = true;
        ok = true;
    }
    
    private IEnumerator secondCoroutine()
    {
        ok = false;
        yield return new WaitForSeconds(1.0f);
        seconds += 1.0f;
        ok = true;
    }
}
