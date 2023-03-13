using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float spinAmountX = 0f;
    [SerializeField] float spinAmountY = 0.5f;
    [SerializeField] float spinAmountZ = 0f;
    //CACHE - references for readability or speed
    //STATE - private instance (member) variables
    //PUBLIC METHOD
    void Update()
    {
        StartSpinning();
    }
    //PRIVATE METHOD
    private void StartSpinning()
    {
        if (Time.time > 35f)
        {
            transform.Rotate(spinAmountX, spinAmountY, spinAmountZ);
        }
        else if (Time.time <= 35f)
        {
            transform.Rotate(spinAmountX, -spinAmountY, spinAmountZ);
        }
    }
}


