using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSFXEnablerPB : MonoBehaviour
{
    //Variable para el DoorSFX Gameobject (con el fin de activar el SFX Script cuando este en trigger, asi no suena on start)
    private SoundEventTriggerOnCollision PuertaPB;

    private void Awake()
    {
        //setteo el componente de SFX Script para activarlo en Enter Trigger
        PuertaPB = GetComponentInChildren<SoundEventTriggerOnCollision>();
        PuertaPB.enabled = false;
        Debug.Log("Puerta SFX Component disabled: " + gameObject.name, gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PuertaPB.enabled = true;
            Debug.Log("Puerta SFX Component enabled: " + gameObject.name, gameObject);
        }
    }
}
