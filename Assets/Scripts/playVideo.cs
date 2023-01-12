using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVideo : MonoBehaviour
{
    public bool playVideoOnStart = false;
    public GameObject videoPlayer;

    void Start()
    {
        if (videoPlayer != null)
        {
            if (playVideoOnStart == false)
            {
                videoPlayer.SetActive(false);
            }
            else
            {
                videoPlayer.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            videoPlayer.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            videoPlayer.SetActive(false);
        }
    }
}   
    