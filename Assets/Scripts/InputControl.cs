using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public bool isThrusting;
    public bool isRotateLeft;
    public bool isRotateRight;


    public void OnThrust()
    {
        isThrusting = !isThrusting;
    }

    public void OnRotateLeft()
    {
        isRotateLeft = !isRotateLeft;
    }
    public void OnRotateRight()
    {
        isRotateRight = !isRotateRight;
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
