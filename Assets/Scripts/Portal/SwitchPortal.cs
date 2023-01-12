using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPortal : MonoBehaviour
{
    [Header("Portals")]
    public Portal portalA;
    public Portal portalB;
    public Portal portalC;
    public Portal portalProvisorio;

    [Header("Puertas")]
    public PortalDoorTrigger triggerPuertaA;
    public PortalDoorTrigger triggerPuertaB;
    public PortalDoorTrigger triggerPuertaC;


    private void Update()
    {
        if (triggerPuertaA.insidePortalDoorTrigger)
        {
            portalA.linkedPortal = portalB;
            portalB.linkedPortal = portalA;
            portalC.linkedPortal = portalProvisorio;
            portalProvisorio.linkedPortal = portalC;
        }
        
        if (triggerPuertaB.insidePortalDoorTrigger || triggerPuertaC.insidePortalDoorTrigger)
        {
            portalA.linkedPortal = portalProvisorio;
            portalB.linkedPortal = portalC;
            portalC.linkedPortal = portalB;
            portalProvisorio.linkedPortal = portalA;
        }/*
        if (triggerPuertaC.insidePortalDoorTrigger)
        {
            portalA.linkedPortal = portalProvisorio;
            portalB.linkedPortal = portalC;
            portalC.linkedPortal = portalB;
            portalProvisorio.linkedPortal = portalA;
        }*/
    }
}
