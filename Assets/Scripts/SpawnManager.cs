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


    void Awake()
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

        int count = seconds;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        countdownText.text = "GO !";
        hideCountdown = true;

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
            if (alpha <= 0) hideCountdown = false;
        }
    }

    
}
