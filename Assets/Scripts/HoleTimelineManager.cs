using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class HoleTimelineManager : MonoBehaviour
{
    [SerializeField] bool debug = false;

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

            if (debug)
            {
                Debug.Log("CounterManager count is " + counter);
            }
        }
    }

    public PlayableDirector[] playableDirectors;
    public PlayableDirector Timeline1;
    public PlayableDirector Timeline2;
    public PlayableDirector Timeline3;
    public PlayableDirector Timeline4;
    private void Start()
    {
        StartCoroutine(HoleCoroutine());
    }
    int arrayvalue = 0;
    //agrego esto por si tiene 1 o 2 portales.
    //En caso de que active 2 portales simultaneamente, puedo cambiar el valor a 2 en el inspector
    public int countermultiplier = 1;
    bool hole1()
    {
        if (counter == (1 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool hole2()
    {
        if (counter == (2 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool hole3()
    {
        if (counter == (3 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool hole4()
    {
        if (counter == (4 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private IEnumerator HoleCoroutine()
    {
        yield return new WaitUntil(hole1);
        //Timeline1.Play();
        PlayTimeline();
        yield return new WaitUntil(hole2);
        //Timeline2.Play(); 
        PlayTimeline();
        yield return new WaitUntil(hole3);
        //Timeline3.Play();
        PlayTimeline();
        yield return new WaitUntil(hole4);
        Timeline4.Play();
        //PlayTimeline();
    }
    void PlayTimeline()
    {
        playableDirectors[arrayvalue].Play();
        Debug.Log("Arrayvalue: " + arrayvalue);
        arrayvalue++;
    }
}
