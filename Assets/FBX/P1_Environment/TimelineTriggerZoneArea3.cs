using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineTriggerZoneArea3 : MonoBehaviour
{/*
    [Header("Component References")]
    public TimelineController3 timelineController;

    [Header("Settings")]
    public string playerString = "Player";
    public string collisionTag = "Player";


    void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.tag == collisionTag)
        {
            timelineController.PlayerEnteredZone();
            Debug.Log("Player Entered Cutscene Trigger Zone");
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.tag == collisionTag)
        {
            timelineController.PlayerExitedZone();
            Debug.Log("Player Exited Cutscene Trigger Zone");
        }
    }
    */
    [SerializeField] bool debug = false;

    public TimelineController3 timelineController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timelineController.PlayerEnteredZone();
            if (debug)
            {
                Debug.Log("Player entered trigger" + gameObject.name, gameObject);
            }

            timelineController.Counter++;

            if (debug)
            {
                Debug.Log("Counter is " + timelineController.Counter);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            timelineController.PlayerExitedZone();
            Debug.Log("Player Exited Cutscene Trigger Zone");
        }
    }
}
