using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float verticalThrustForce = 1000f;
    [SerializeField] float horizontalThrustForce = 10f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem[] EngineParticle;


    //CACHE - references for readability or speed
    Rigidbody _rigidbody;
    AudioSource _audioSource;
    InputControl inputManager;


    //STATE - private instance (member) variables
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        inputManager = GetComponent<InputControl>();
    }



    void FixedUpdate()
    {
        //ProcessThurst();
        //ProcessRotation();
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(inputManager.isThrusting)
        {
            StartThrusting();
        }
        if(inputManager.isRotateLeft)
        {
            RotateLeft();
        }
        if(inputManager.isRotateRight)
        {
            RotateRight();
        }
        else if(!inputManager.isThrusting)
        {
            StopThrusting();
        }
        else if(!inputManager.isRotateRight || !inputManager.isRotateLeft)
        {
            StopRotating();
        }
        

    }

    //public void ProcessThurst()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartThrusting();
    //    }
    //    else if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        StopThrusting();
    //    }
    //}
    //public void ProcessRotation()
    //{
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        RotateRight();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        RotateLeft();
    //    }
    //    else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
    //    {
    //        StopRotating();
    //    }
    //}
    public void StartThrusting()
    {
        Debug.Log("Thrusting!" + Vector3.up * verticalThrustForce * Time.deltaTime);

        _rigidbody.AddRelativeForce(Vector3.up * verticalThrustForce * Time.deltaTime);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(mainEngine);
        }
        if (!EngineParticle[0].isPlaying)
        {
            EngineParticle[0].Play();// EngineParticle[0] = Main Engine Particle
        }


    }

    public void StopThrusting()
    {
       Debug.Log("Not Thrusting!");
        _audioSource.Stop();
        EngineParticle[0].Stop();
    }

    public void RotateRight()
    {
        Debug.Log("Right!");

        RotateRocket(-horizontalThrustForce);
        if (!EngineParticle[2].isPlaying) // EngineParticle[2] = Left Thruster Particle
        {
            EngineParticle[2].Play();
        }


    }

    public void RotateLeft()
    {
        Debug.Log("Left!");

        RotateRocket(horizontalThrustForce);
        if (!EngineParticle[1].isPlaying) // EngineParticle[1] = Right Thruster Particle
        {
            EngineParticle[1].Play();
        }

    }

    public void StopRotating()
    {
        Debug.Log("Not Rotating!");
        EngineParticle[1].Stop();
        EngineParticle[2].Stop();
    }

    void RotateRocket(float horizontalInput)
    {
        //freeze rotation to rotate rocket manually
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * horizontalInput * Time.deltaTime, Space.Self);
        // unfreeze after rotating the rocket so the physic system can take over
        _rigidbody.freezeRotation = false;
    }

}
