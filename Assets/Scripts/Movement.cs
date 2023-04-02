using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Movement : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float verticalThrustForce = 150f;
    [SerializeField] float horizontalThrustForce = 10f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem[] EngineParticle;

    //CACHE - references for readability or speed
    Rigidbody _rigidbody;
    AudioSource _audioSource;

    //STATE - private instance (member) variables

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        //ProcessThurst();
        //ProcessRotation();
    }

    //void ProcessThurst()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        StartThrusting();
    //    }
    //    else
    //    {
    //        StopThrusting();
    //    }
    //}
    //void ProcessRotation()
    //{
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        RotateRight();
    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        RotateLeft();
    //    }
    //    else
    //    {
    //        StopRotating();
    //    }
    //}
    public void StartThrusting(InputAction.CallbackContext context)
    {
        Debug.Log("Thrusting!");
        if (context.performed)
        {
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
        else if (context.canceled)
        {
            StopThrusting();
        }

    }

    public void StopThrusting()
    {
        Debug.Log("Not Thrusting!");
        _audioSource.Stop();
        EngineParticle[0].Stop();
    }

    public void RotateRight(InputAction.CallbackContext context)
    {
        Debug.Log("Right!");
        if (context.performed)
        {
            RotateRocket(-horizontalThrustForce);
            if (!EngineParticle[2].isPlaying) // EngineParticle[2] = Left Thruster Particle
            {
                EngineParticle[2].Play();
            }
        }
        else if (context.canceled)
        {
            StopRotating();
        }

    }

    public void RotateLeft(InputAction.CallbackContext context)
    {
        Debug.Log("Left!");
        if (context.performed)
        {
            RotateRocket(horizontalThrustForce);
            if (!EngineParticle[1].isPlaying) // EngineParticle[1] = Right Thruster Particle
            {
                EngineParticle[1].Play();
            }
        }
        else if (context.canceled)
        {
            StopRotating();
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
