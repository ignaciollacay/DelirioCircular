using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController2 : MonoBehaviour
{
    [Header("Timeline References")]
    public PlayableDirector playableDirector;

    [Header("Player Input Settings")]
    private FPSController fpsController;

    [Header("Trigger Zone Settings")]
    public GameObject triggerZoneObject;
    public MouseOver MouseOverTarget;
    //public HoudiniLook _houdiniLook;

    private bool playerInZone = false;
    private bool timelinePlaying = false;
    private bool timelineHasPlayed = false;
    private float timelineDuration;

    public bool forwardplayback = true;
    //private bool reversedplayback = false;
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
            if ((MouseOverTarget.mouseIsOver) && (forwardplayback == true))
            {
                playableDirector.time = 0;
                PlayTimeline();
            }
            else if ((!MouseOverTarget.mouseIsOver) && (timelineHasPlayed) && (forwardplayback == false))
            {
                playableDirector.time = 5.6f;
                PlayTimeline();
            }
        }
    }
    void PlayTimeline()
    {
        if (!timelineHasPlayed)
        {
            playableDirector.Play();
            timelineHasPlayed = true;
        }
        else
        {
            playableDirector.Resume();
        }

        timelinePlaying = true;

        StartCoroutine(WaitForTimelineToFinish());
    }
    IEnumerator WaitForTimelineToFinish()
    {
        yield return new WaitForSeconds(5.6f);
        playableDirector.Pause();

        if (forwardplayback == true)
        {
            forwardplayback = false;
        }
        else
        {
            forwardplayback = true;
        }
        
        timelinePlaying = false;
    }
}
/*
{
    [Header("Timeline References")]
    public PlayableDirector[] playableDirector;

    [Header("Player Input Settings")]
    private FPSController fpsController;

    [Header("Trigger Zone Settings")]
    public GameObject triggerZoneObject;
    public MouseOver MouseOverTarget;
//public HoudiniLook _houdiniLook;

private bool playerInZone = false;
private bool timelinePlaying = false;
private bool timelineHasPlayed = false;
private float timelineDuration;
private int index;
private int otherIndex;


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
        if (MouseOverTarget.mouseIsOver)
        {
            index = 0;
            otherIndex = 1;
            PlayTimeline();
            //ResetOtherTimeline();
        }
        else if ((!MouseOverTarget.mouseIsOver) && (timelineHasPlayed))
        {
            index = 1;
            otherIndex = 0;
            PlayTimeline();
        }
    }
}
void PlayTimeline()
{
    playableDirector[index].Play();

    //triggerZoneObject.SetActive(false);

    timelinePlaying = true;
    timelineHasPlayed = true;

    StartCoroutine(WaitForTimelineToFinish());

    playableDirector[index].Pause();
}
IEnumerator WaitForTimelineToFinish()
{
    timelineDuration = (float)playableDirector[0].duration;

    yield return new WaitForSeconds(timelineDuration);

    timelinePlaying = false;



    ResetOtherTimeline();
}

void ResetOtherTimeline()
{
    //playableDirector[otherIndex].Pause();
    playableDirector[otherIndex].time = playableDirector[otherIndex].initialTime;
}
}
*/