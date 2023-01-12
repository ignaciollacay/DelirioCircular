using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoorTrigger : MonoBehaviour
{
    //la tenia como publica, no se bien por que. supongo que era por debug. cualquier cosa agregar a serialized
    //va mentira, mejor no. Creo que es porque se comunica con otro script. 
    //ahora no se cual. mejor no toco que estoy viendo el Counter
    public bool insidePortalDoorTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player is inside Portal Door Trigger" + gameObject.name, gameObject);
            insidePortalDoorTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            insidePortalDoorTrigger = false;
        }
    }
}
