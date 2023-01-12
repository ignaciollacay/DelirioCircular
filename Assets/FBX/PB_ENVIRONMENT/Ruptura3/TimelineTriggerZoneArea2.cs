using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineTriggerZoneArea2 : MonoBehaviour
{
    [Header("Component References")]
    public TimelineController2 timelineController2;

    [Header("Settings")]
    public string playerString = "Player";
    public string collisionTag = "Player";


    void OnTriggerEnter(Collider theCollision)
    {
        if (theCollision.tag == collisionTag)
        {
            timelineController2.PlayerEnteredZone();
            Debug.Log("Player Entered Cutscene Trigger Zone");
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.tag == collisionTag)
        {
            timelineController2.PlayerExitedZone();
            Debug.Log("Player Exited Cutscene Trigger Zone");
        }
    }
}
