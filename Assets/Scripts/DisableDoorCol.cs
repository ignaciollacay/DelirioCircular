using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoorCol : MonoBehaviour
{
    public Collider DoorCol;
    public int waitTime = 3;

    public PortalDoorTrigger portalDoorTrigger1;
    public PortalDoorTrigger portalDoorTrigger2;
    private IEnumerator DisableDoorCollider()
    {
        yield return new WaitForSeconds(waitTime);
        DoorCol.enabled = true;
    }
    private void Update()
    {
        if ((portalDoorTrigger1.insidePortalDoorTrigger) || (portalDoorTrigger2.insidePortalDoorTrigger))
        {
            DoorCol.enabled = false;
        }
        if ((portalDoorTrigger1.insidePortalDoorTrigger == false) && (portalDoorTrigger2.insidePortalDoorTrigger == false))
        {
            StartCoroutine(DisableDoorCollider());
        }
    }
}
