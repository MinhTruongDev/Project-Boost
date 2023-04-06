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
    [SerializeField] ParticleSystem[] _particleSystems;

    //CACHE - references for readability or speed
    AudioSource _audioSource;

    //STATE - private instance (member) variables
    private int currentSceneIndex;
    private bool isTransitioning = false;
    private bool collisionDisabled = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //RespondToDebugKey();
    }

    private void RespondToDebugKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Success":
                InvokeMethod("LoadNextLevel", delayTime, other.gameObject.tag);
                break;
            case "Friendly":
                break;
            default:
                InvokeMethod("ReloadScene", delayTime, other.gameObject.tag);
                break;
        }

    }

    private void PlayAudio(string objectTag)
    {
        switch (objectTag)
        {
            case "Success":
                _audioSource.clip = _audioClips[0];
                _audioSource.Play();
                break;
            default: //Death
                _audioSource.clip = _audioClips[1];
                _audioSource.Play();
                break;
        }
    }

    void InvokeMethod(string methodName, float delayTime, string objectTag)
    {
        isTransitioning = true;
        PlayAudio(objectTag);
        PlayParticleSystem(objectTag);
        GetComponent<Movement>().enabled = false;
        Invoke(methodName, delayTime);
    }

    private void PlayParticleSystem(string objectTag)
    {

        switch (objectTag)
        {
            case "Success":
                _particleSystems[0].Play();
                break;
            default: //Death
                _particleSystems[1].Play();
                break;
        }
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
