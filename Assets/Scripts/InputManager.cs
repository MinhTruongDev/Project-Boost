using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public bool isThrusting;
    public bool isRotateLeft;
    public bool isRotateRight;


    public void OnThrust(InputValue inputValue)
    {
        isThrusting = Convert.ToBoolean(inputValue.Get<float>());
    }

    public void OnRotateLeft(InputValue inputValue)
    {
        isRotateLeft = Convert.ToBoolean(inputValue.Get<float>());
    }
    public void OnRotateRight(InputValue inputValue)
    {
        isRotateRight = Convert.ToBoolean(inputValue.Get<float>());
    }
}
