using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    public float PackageDispearTime = 1;
    // defaul of bool is false 
    void OnCollisionEnter2D(Collision2D other)
     {
        Debug.Log("BOOM");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log(other.tag);
        if(other.CompareTag("Package") && hasPackage == false)
        {
            
            Debug.Log("Package pick up");
            hasPackage = true;
            Debug.Log(hasPackage);
            Destroy(other.gameObject,PackageDispearTime);
        }
        else if(other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
            Debug.Log(hasPackage);
        }
    }
}
