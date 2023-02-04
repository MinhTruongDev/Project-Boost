using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float verticalThrustForce = 150f;
    [SerializeField] float horizontalThrustForce = 10f;
    [SerializeField] AudioClip mainEngine;

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
        ProcessThurst();
        ProcessRotation();
    }

    void ProcessThurst()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(mainEngine);
            }                        
            _rigidbody.AddRelativeForce(Vector3.up * verticalThrustForce * Time.deltaTime);                       
            //Debug.Log(Vector3.up * verticalThrustForce * Time.deltaTime);
        }
        else
            _audioSource.Stop();

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateRocket(-horizontalThrustForce);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateRocket(horizontalThrustForce);
        }
    }

    void RotateRocket(float horizontalInput)
    {
        _rigidbody.freezeRotation = true; //freeze rotation to rotate rocket manually
        transform.Rotate(Vector3.forward * horizontalInput * Time.deltaTime,Space.Self);
        //Debug.Log(Vector3.forward * horizontalInput * Time.deltaTime);
        _rigidbody.freezeRotation = false; // unfreeze after rotating the rocket so the physic system can take over
    }

}
