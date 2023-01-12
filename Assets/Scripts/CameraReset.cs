using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Camera>().enabled = true;
        gameObject.GetComponent<Camera>().enabled = false;
        gameObject.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
