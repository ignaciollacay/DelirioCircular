using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySlow : MonoBehaviour
{
    private FPSController FPC;
    public float gravity = 3f;
    public float gravityMultiplier = 0.05f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player is inside Gravity Slow " + gameObject.name, gameObject);
        if (other.gameObject.tag == "Player")
        {
            FPC = other.gameObject.GetComponent<FPSController>();
            FPC.gravity = gravity;
            FPC.m_GravityMultiplier = gravityMultiplier;
            Debug.Log("Player gravity changed to: " + gravity + ". Player gravity multiplier set to: " + gravityMultiplier);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player is outside Gravity Slow " + gameObject.name, gameObject);
        if (other.gameObject.tag == "Player")
        {
            gravity = 10;
            gravityMultiplier = 2;
            FPC = other.gameObject.GetComponent<FPSController>();
            FPC.gravity = gravity;
            FPC.m_GravityMultiplier = gravityMultiplier;
            Debug.Log("Player gravity changed to: " + gravity + ". Player gravity multiplier set to: " + gravityMultiplier);
        }
    }
}
