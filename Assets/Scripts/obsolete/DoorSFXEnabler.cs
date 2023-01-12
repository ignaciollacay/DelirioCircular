using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSFXEnabler : MonoBehaviour
{
    //Variable para el DoorSFX Gameobject (con el fin de activar el SFX Script cuando este en trigger, asi no suena on start)
    public DoorShutSfx Puerta2C;
    
    private void Awake()
    {
        //setteo el componente de SFX Script para activarlo en Enter Trigger
        Puerta2C = GetComponentInChildren<DoorShutSfx>();
        Puerta2C.enabled = false;
        Debug.Log("Puerta SFX Component disabled: " + gameObject.name, gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Puerta2C.enabled = true;
            Debug.Log(gameObject.name + ": Puerta SFX Component enabled");
            Debug.Log("Puerta SFX Component enabled: " + gameObject.name, gameObject);
        }
    }
}
