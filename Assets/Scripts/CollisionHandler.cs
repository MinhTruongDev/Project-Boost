using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip[] _audioClips;

    //CACHE - references for readability or speed
    AudioSource _audioSource;

    //STATE - private instance (member) variables
    private int currentSceneIndex;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Success":
                InvokeMethod("LoadNextLevel", delayTime, other.gameObject.tag);
                break;
            case "Friendly":
                Debug.Log("Friendly");
                break;
            default:                
                InvokeMethod("ReloadScene", delayTime, other.gameObject.tag);
                break;
        }
    }

    private void PlayAudio(string objectTag)
    {
        switch(objectTag)
        {
            case "Success":
                if (_audioSource.isPlaying && _audioSource.clip == _audioClips[1]) break;
                else
                {
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    break;
                }
            default:
                if (_audioSource.isPlaying && _audioSource.clip == _audioClips[0]) break;
                else
                {
                    _audioSource.clip = _audioClips[1];
                    _audioSource.Play();
                    break;
                }
                
        }
        
    }

    void InvokeMethod(string methodName, float delayTime ,string objectTag)
    {
        PlayAudio(objectTag);
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
