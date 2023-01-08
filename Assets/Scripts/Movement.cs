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


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
            _rigidbody.AddRelativeForce(Vector3.up * verticalThrustForce * Time.deltaTime);
            Debug.Log(Vector3.up * verticalThrustForce * Time.deltaTime);
        }
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
        transform.Rotate(Vector3.forward * horizontalInput * Time.deltaTime,Space.Self);
        Debug.Log(Vector3.forward * horizontalInput * Time.deltaTime);
    }

}
