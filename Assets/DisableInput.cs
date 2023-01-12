using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInput : MonoBehaviour
{
    private GameObject thePlayer;

    bool insideTrigger = false;
    bool inputReleased = false;
    private void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InputRelease());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            insideTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            insideTrigger = false;
        }
    }
    private void Update()
    {
        if ((insideTrigger) && (!inputReleased))
        {
            thePlayer.GetComponent<FPSController>().inputAllowed = false;
        }
        else
        {
            thePlayer.GetComponent<FPSController>().inputAllowed = true;
        }

        if (thePlayer.GetComponent<FPSController>().inputAllowed == false)
        {
            StartCoroutine(InputRelease());
        }
    }
    IEnumerator InputRelease()
    {
        yield return new WaitForSeconds(3);
        thePlayer.GetComponent<FPSController>().inputAllowed = true;
        inputReleased = true;
    }
}
