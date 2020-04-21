using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private SpawnManagerScriptableObject spawnData;

    [SerializeField]
    private Text countdownText;

    [SerializeField]
    private int countdownDuration = 3;

    private bool hideCountdown = false;
    private float hidingFactor = 0;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip beepClip1;

    [SerializeField]
    private AudioClip beepClip2;

    [SerializeField]
    private ChronoUI chrono;


    void Start()
    {
        if (spawnData == null)
        {
            Debug.LogError("Spawn Data hasn't been specified");
        }

        StartGame();
    }



    void StartGame()
    {
        
        StartCoroutine(Countdown(countdownDuration));
    }

    IEnumerator Countdown(int seconds)
    {
        spawnData.PlayerObject.GetComponent<IceCubeController>().EnableSimulation(false);
        spawnData.PlayerObject.GetComponent<IceCubeController>().EnableGravity(false);

        chrono.counterText.alpha = 0;

        int count = seconds;
        countdownText.color = new Color(countdownText.color.r, countdownText.color.g, countdownText.color.b, 1);
        while (count > 0)
        {
            countdownText.text = count.ToString();
            audioSource.clip = beepClip1;
            audioSource.Play();
            yield return new WaitForSeconds(1);
            count--;
        }

        countdownText.text = "GO !";
        audioSource.clip = beepClip2;
        audioSource.Play();
        hideCountdown = true;
        chrono.ResetChrono(true);

        spawnData.PlayerObject.GetComponent<IceCubeController>().EnableGravity(true);
        spawnData.PlayerObject.GetComponent<IceCubeController>().EnableSimulation(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            spawnData.ResetCubePosition();
            StartGame();
        }

        if(hideCountdown)
        {
            hidingFactor += (Time.deltaTime * 0.75f);
            float alpha = Mathf.Lerp(1, 0, hidingFactor);
            countdownText.color = new Color(countdownText.color.r, countdownText.color.g, countdownText.color.b, alpha);
            if (alpha <= 0)
            {
                hideCountdown = false;
                hidingFactor = 0;
            }
        }
    }

    
}
