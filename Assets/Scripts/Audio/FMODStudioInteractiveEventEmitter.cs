using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODStudioInteractiveEventEmitter : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string selectsound;
    public FMOD.Studio.EventInstance soundevent;

    public KeyCode presstoplaysound;
    private bool _isInsideTrigger = false;
    private bool _isOutsideTrigger = false;

    void Start()
    {
        soundevent = FMODUnity.RuntimeManager.CreateInstance(selectsound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            _isOutsideTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            _isOutsideTrigger = true;
        }
    }

    void Update()
    {
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundevent, GetComponent<Transform>(), GetComponent<Rigidbody>());
            Playsound();
        }
    }

    void Playsound()
    {
        if (_isInsideTrigger && Input.GetKey(presstoplaysound))
        {
            FMOD.Studio.PLAYBACK_STATE fmodPbState;
            soundevent.getPlaybackState(out fmodPbState);
            if (fmodPbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                soundevent.start();
            }
        }
        else if (_isOutsideTrigger && Input.GetKey(presstoplaysound))
        {
            if (Input.GetKey(presstoplaysound))
            {
                soundevent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}
