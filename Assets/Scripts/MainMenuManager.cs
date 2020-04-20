using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    private LevelSetScriptableObject levelSet;

    // Start is called before the first frame update
    void Start()
    {
        levelSet.currentLevelIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            levelSet.LoadNextScene();
        }
        else if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
