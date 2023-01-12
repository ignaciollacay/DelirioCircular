using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public doorScript _doorScript;

    // Start is called before the first frame update
    void Start()
    {
        _doorScript = GetComponent<doorScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _doorScript.enabled = false;
        }
    }
}

