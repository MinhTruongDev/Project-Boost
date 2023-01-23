using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float delayTime = 1f;

    private int currentSceneIndex;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                InvokeMethod("LoadNextLevel", delayTime);
                break;
            case "Friendly":
                Debug.Log("Friendly");
                break;
            default:
                InvokeMethod("ReloadScene", delayTime);                
                break;
        }
    }
    void InvokeMethod(string methodName, float delayTime)
    {
        GetComponent<Movement>().enabled = false;
        Invoke(methodName, delayTime);
    }
    void ReloadScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
