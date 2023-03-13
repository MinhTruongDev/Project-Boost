using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    Vector3 startingPosition;
    float movementFactor;
    float cycles;
    const float tau = Mathf.PI * 2; // constant value of 6.283....


    //CACHE - references for readability or speed

    //STATE - private instance (member) variables

    //PUBLIC METHOD
    void Start()
    {
        startingPosition = transform.position;
    }
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        cycles = Time.time / period; // return continually growing value overtime || decide how much the wall oscillating
        float rawSinWave = Mathf.Sin(cycles * tau); //return value (-1,1)
        movementFactor = (rawSinWave + 1f) / 2f; // to make rawSinWave return value (0,1) for movementFactor
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;



    }
    //PRIVATE METHOD
}
