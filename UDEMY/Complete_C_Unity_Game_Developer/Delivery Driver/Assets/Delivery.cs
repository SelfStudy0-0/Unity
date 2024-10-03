using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    // defaul of bool is false 
    void OnCollisionEnter2D(Collision2D other)
     {
        Debug.Log("BOOM");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.tag);
        if(other.CompareTag("Package"))
        {
            
            Debug.Log("Package pick up");
            hasPackage = true;
            Debug.Log(hasPackage);
        }
        else if(other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
            Debug.Log(hasPackage);
        }
    }
}
