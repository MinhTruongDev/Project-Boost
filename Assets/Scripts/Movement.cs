using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float verticalThrustForce = 150f;
    [SerializeField]
    float horizontalThrustForce = 10f;

    Rigidbody _rigidbody;
    AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
                _audioSource.Play(); 
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
