using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public GameObject Puerta;
    public bool lockDoor;
    public bool triggerOnce = true;
    //public bool pBDoor;

    private bool hasTriggered;
    doorInteraction DoorInteraction;
    //DoorShutSfx doorShutSfx;
    //SoundEventTriggerOnCollision soundEventTriggerOnCollision;

    void Start()
    {
        DoorInteraction = Puerta.GetComponentInChildren<doorInteraction>();
        /*
        if (pBDoor)
        {
            soundEventTriggerOnCollision = Puerta.GetComponentInChildren<SoundEventTriggerOnCollision>();
            doorShutSfx = null;
        }
        else
        {
            doorShutSfx = Puerta.GetComponentInChildren<DoorShutSfx>();
            soundEventTriggerOnCollision = null;
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (triggerOnce && hasTriggered)
            {
                Debug.Log("Triggered once && has triggered " + Puerta.name, Puerta);
                return;
            }

            Debug.Log("Player has entered Lock Door collider" + gameObject.name, gameObject);

            
            if (lockDoor == true)
            {
                DoorInteraction._isLocked = true;
                Debug.Log("Player has enabled Locked Door Interaction " + Puerta.name, Puerta);
                /*
                if (pBDoor)
                {
                    soundEventTriggerOnCollision._isLocked = true;
                }
                else
                {
                    doorShutSfx._isLocked = true;
                }
                Debug.Log("Player has enabled Locked Door SFx " + Puerta.name, Puerta);
                */
                hasTriggered = true;
                Debug.Log("has triggered " + Puerta.name, Puerta);
            }
            else if (lockDoor == false)
            {
                DoorInteraction._isLocked = false;
                Debug.Log("Player has disabled Locked Door Interaction " + Puerta.name, Puerta);
                /*
                if (pBDoor)
                {
                    soundEventTriggerOnCollision._isLocked = false;
                }
                else
                {
                    doorShutSfx._isLocked = false;
                }
                Debug.Log("Player has disabled Locked Door SFx " + Puerta.name, Puerta);
                */
            }
        }
    }
}
/* BACKUP
{
    public GameObject Puerta_SFX;
    public GameObject Puerta_Anim;

    public bool lockDoor;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered Lock Door collider");
        //DoorLock doorLock = new DoorLock();

        //doorLock.Locked = true;

        if (lockDoor == true)
        {
            Puerta_SFX.GetComponent<SoundEventTriggerOnCollision>()._isLocked = true;
            Debug.Log("Player has enabled Locked Door SFx");
            Puerta_Anim.GetComponent<doorInteraction>()._isLocked = true;
            Debug.Log("Player has enabled Locked Door Interaction");
        }
        else if (lockDoor == false)
        {
            Puerta_SFX.GetComponent<SoundEventTriggerOnCollision>()._isLocked = false;
            Debug.Log("Player has disabled Locked Door SFx");
            Puerta_Anim.GetComponent<doorInteraction>()._isLocked = false;
            Debug.Log("Player has disabled Locked Door Interaction");
        }
    }
}
*/
