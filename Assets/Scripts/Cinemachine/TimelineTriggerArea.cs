using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineTriggerArea : MonoBehaviour
{
    [Header("Component References")]
    public TimelinePlaybackManager timelinePlaybackManager;

    [Header("Settings")]
    public string playerString = "Player";
    public string collisionTag = "Player";


    void OnTriggerEnter(Collider theCollision)
    {
        if(theCollision.tag == collisionTag)
        {
            timelinePlaybackManager.PlayerEnteredZone();
            Debug.Log("Player Entered Cutscene Trigger Zone");
        }
    }

    void OnTriggerExit(Collider theCollision)
    {
        if (theCollision.tag == collisionTag)
        {
            timelinePlaybackManager.PlayerExitedZone();
            Debug.Log("Player Exited Cutscene Trigger Zone");
        }
    }
}
