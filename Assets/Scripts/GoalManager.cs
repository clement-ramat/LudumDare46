using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour
{
    [SerializeField]
    private SpawnManagerScriptableObject spawnData;

    [SerializeField]
    private LevelSetScriptableObject levelSet;

    [SerializeField]
    private string tagToCheck = "Player";

    [SerializeField]
    private float waitTimeBeforeChangingScene = 3f;

    void Awake()
    {
        if (spawnData == null)
        {
            Debug.LogError("Spawn Data hasn't been specified");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToCheck)
        {
            Debug.Log("Goal reached");
            StartCoroutine(GoalReached());
        }
    }

    private IEnumerator GoalReached()
    {
        spawnData.CurrentCamera.GetComponent<CameraFollow>().StopFollowing();
        try
        {
            spawnData.CurrentCamera.GetComponent<CameraFollow>().EnableGlassView();
        } catch
        {
            Debug.Log("le verre n'as pas été placé !!");
        }
       

        yield return new WaitForSeconds(waitTimeBeforeChangingScene);

        levelSet.LoadNextScene();
    }
}
