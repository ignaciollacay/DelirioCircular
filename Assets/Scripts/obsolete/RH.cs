using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH : MonoBehaviour
{
    public GameObject FloorRH;

    void Start()
    {
        FloorRH.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FloorRH.SetActive(false);
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            videoPlayer.SetActive(false);
        }
    }
    */
}