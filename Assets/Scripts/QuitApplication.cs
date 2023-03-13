

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    //PARAMETERS
    //CACHE - references for readability or speed
    //STATE - private instance (member) variables
    //PUBLIC METHOD
    //PRIVATE METHOD   

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
