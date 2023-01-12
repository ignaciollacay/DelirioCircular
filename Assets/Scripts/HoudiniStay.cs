using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoudiniStay : MonoBehaviour
{
    public GameObject[] enableOnStay;
    public GameObject[] disableOnStay;
    public GameObject[] disableOnExit;
    public GameObject[] enableOnExit;
    
    private void OnTriggerStay(Collider other)
    {
        {
            if (other.tag == "Player")
            {
                foreach (GameObject goEnableOnStay in enableOnStay)
                {
                    goEnableOnStay.SetActive(true);
                }
                foreach (GameObject goDisableOnStay in disableOnStay)
                {
                    goDisableOnStay.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.tag == "Player")
            {
                foreach (GameObject goEnableOnExit in enableOnExit)
                {
                    goEnableOnExit.SetActive(true);
                    Debug.Log("Triggered: " + gameObject.name, gameObject);
                }
            }
            {
                foreach (GameObject goDisableOnExit in disableOnExit)
                {
                    goDisableOnExit.SetActive(false);
                    Debug.Log("Triggered: " + gameObject.name, gameObject);
                }
            }
        }
    }
}
