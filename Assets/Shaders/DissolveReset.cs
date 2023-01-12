using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveReset : MonoBehaviour
{
    public bool _DissolveReset = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _DissolveReset = true;
        }
        else
        {
            _DissolveReset = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _DissolveReset = false;
        }
    }
}
