using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelSet", menuName = "ScriptableObjects/LevelSet", order = 1)]
public class LevelSetScriptableObject : ScriptableObject
{
    // The index of the first level in the build settings
    [SerializeField]
    private int levelStartIndex = 0;

    [SerializeField]
    private int nbLevels = 1;

    public int currentLevelIndex;


    public void LoadNextScene()
    {
        currentLevelIndex++;

        if (currentLevelIndex >= nbLevels)
        {
            currentLevelIndex = levelStartIndex;
        }

        Debug.Log("Loading Scene of index" + levelStartIndex + currentLevelIndex);
        SceneManager.LoadScene(levelStartIndex + currentLevelIndex);
    }

}
