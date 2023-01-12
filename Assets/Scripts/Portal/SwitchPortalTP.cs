using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPortalTP : MonoBehaviour
{
    /// <summary>
    /// este script lo puedo mejorar.
    /// puedo tener un solo gameobject, total ambos scripts (PortalTeleport y PortalDoorTrigger) son componentes del mismo GO
    /// puedo desactivar el linked portals (manualmente en el Portal Script o automaticamente), y vincular el que sobra a null
    /// puedo sacarlo del Update y hacer una Coroutine, que espere al trigger para ser verdadero y cambiar los vinculos de los portales.
    /// por ahora lo dejo asi que funciona, para priorizar poner el portal en el espejo de L2.
    /// </summary>

    [Header("Portals")]
    public PortalTeleport portalTPA;
    public PortalTeleport portalTPB;
    public PortalTeleport portalTPC;
    public PortalTeleport portalProvisorio;

    [Header("Puertas")]
    public PortalDoorTrigger triggerPuertaA;
    public PortalDoorTrigger triggerPuertaB;
    public PortalDoorTrigger triggerPuertaC;
    private void Update()
    {
        if (triggerPuertaA.insidePortalDoorTrigger)
        {
            portalTPA.linkedPortalTP = portalTPB;
            portalTPB.linkedPortalTP = portalTPA;
            portalTPC.linkedPortalTP = portalProvisorio;
            portalProvisorio.linkedPortalTP = portalTPC;
        }

        if (triggerPuertaB.insidePortalDoorTrigger || triggerPuertaC.insidePortalDoorTrigger)
        {
            portalTPA.linkedPortalTP = portalProvisorio;
            portalTPB.linkedPortalTP = portalTPC;
            portalTPC.linkedPortalTP = portalTPB;
            portalProvisorio.linkedPortalTP = portalTPA;
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
