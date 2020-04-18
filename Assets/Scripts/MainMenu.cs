using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{

    public UnityEvent onGameStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onGameStart?.Invoke();
        }
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
