using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCamera : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Camera>().enabled = false;
    }
}
