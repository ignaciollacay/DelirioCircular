using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController3 : MonoBehaviour
{
    [Header("Timeline References")]
    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;
    public PlayableDirector playableDirector4;
    //public List<TimelineAsset> timelines;

    [Header("Player Input Settings")]
    private FPSController fpsController;

    [Header("Trigger Zone Settings")]
    public GameObject[] triggerZoneObject;
    //public HoudiniLook _houdiniLook;

    private bool playerInZone = false;
    private bool timelinePlaying = false;
    private bool timelineHasPlayed = false;
    private float timelineDuration = 10f;

    private int counter;
    public int Counter
    {
        get
        {
            return counter;
        }
        set
        {
            counter = value;
        }
    }

    public void PlayerEnteredZone()
    {
        playerInZone = true;
    }
    public void PlayerExitedZone()
    {
        playerInZone = false;
    }

    void Update()
    {
        if (playerInZone && !timelinePlaying)
        {
            PlayTimeline();
        }
    }
    
    void PlayTimeline()
    {
        if (counter == 1)
        {
            playableDirector1.Play();
            counter++;
        }
        if (counter == 2)
        {
            playableDirector2.Play();
            counter++;
        }
        if (counter == 3)
        {
            playableDirector3.Play();
            counter++;
        }
        if (counter == 4)
        {
            playableDirector4.Play();
        }
    }
}
