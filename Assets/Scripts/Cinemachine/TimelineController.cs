using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{

    public PlayableDirector playableDirector;

    private bool _isInsideTrigger = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInsideTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInsideTrigger = false;
        }
    }

    void Update()
    {
        if (_isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playableDirector.Play();
            }
        }
    }


}
