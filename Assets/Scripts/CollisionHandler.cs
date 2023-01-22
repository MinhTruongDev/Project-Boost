using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Finish");
                break;
            case "Friendly":
                Debug.Log("Friendly");
                break;
            default:
                Debug.Log("Dead as fuck");
                break;
        }
    }
}
