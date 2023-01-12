using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCollider : MonoBehaviour
{
    public KeyCode interactKey;
    public void OnTriggerStay()
    {
        if (Input.GetKeyDown(interactKey))
        {
            gameObject.GetComponent<Houdini>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Houdini>().enabled = false;
        }
    }
}