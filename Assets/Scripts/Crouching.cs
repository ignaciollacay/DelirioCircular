using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class Crouching : MonoBehaviour
{
            //lo mas prolijo seria asignar esto en Start (), 
            //y que los valores sean 
            //variables publicas (el crouch height) 
            //y una privada (agarrar el valor del Height del character controller)
            //No tengo tiempo para corregir el script ahora. Agrego solo el hold bool

    private CharacterController characterController;

    public bool hold = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.height = 1f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && (hold == false))
        {
            characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.height = 1.7f;
        }
        else if (other.gameObject.tag == "Player" && (hold == true))
        {
            characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.height = 1f;
        }
    }
}