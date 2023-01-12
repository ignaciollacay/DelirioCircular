using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtActive : MonoBehaviour
{
    public GameObject thePlayer;
    private LookAt lookAt;

    private void Start()
    {
        lookAt = thePlayer.GetComponent<LookAt>();
        lookAt.enabled = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lookAt = thePlayer.GetComponent<LookAt>();
            lookAt.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lookAt = thePlayer.GetComponent<LookAt>();
            lookAt.enabled = false;
        }
    }
}
