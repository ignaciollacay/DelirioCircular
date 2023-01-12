using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    //este script es una mod del Portal Script, quitando todo lo que refiere al portal con render texture por motivos de performance
    //a partir de estar usando solo el teleport, sin el portal screen que reemplace con el duplicado de la escena.
    public PortalTeleport linkedPortalTP;
    public bool linkedPortals = true;

    List<PortalTeleportTarget> trackedTargets;

    private void Awake()
    {
        trackedTargets = new List<PortalTeleportTarget>();
    }
    private void LateUpdate()
    {
        HandleTargets();
    }
    void HandleTargets()
    {
        for (int i = 0; i < trackedTargets.Count; i++)
        {
            PortalTeleportTarget target = trackedTargets[i];
            Transform targetT = target.transform;
            var m = linkedPortalTP.transform.localToWorldMatrix * transform.worldToLocalMatrix * targetT.localToWorldMatrix;

            Vector3 offsetFromPortalTP = targetT.position - transform.position;
            int portalSide = System.Math.Sign(Vector3.Dot(offsetFromPortalTP, transform.forward));
            int portalSideOld = System.Math.Sign(Vector3.Dot(target.previousOffsetFromPortalTP, transform.forward));
            // Teleport the traveller if it has crossed from one side of the portal to the other
            if (portalSide != portalSideOld)
            {
                var posOld = targetT.position;
                var rotOld = targetT.rotation;
                target.PortalTeleport(transform, linkedPortalTP.transform, m.GetColumn(3), m.rotation);
                target.playerClone.transform.SetPositionAndRotation(posOld, rotOld);
                linkedPortalTP.OnEnterPortalTP(target);
                trackedTargets.RemoveAt(i);
                i--;
            }
            else
            {
                target.playerClone.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
                target.previousOffsetFromPortalTP = offsetFromPortalTP;
            }
        }
    }
    void OnEnterPortalTP (PortalTeleportTarget target)
    {
        if (!trackedTargets.Contains(target))
        {
            target.EnterPortalTPThreshold();
            target.previousOffsetFromPortalTP = target.transform.position - transform.position;
            trackedTargets.Add(target);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<PortalTeleportTarget>();
        if (target)
        {
            OnEnterPortalTP(target);
        }
    }
    void OnTriggerExit(Collider other)
    {
        var target = other.GetComponent<PortalTeleportTarget>();
        if (target && trackedTargets.Contains(target))
        {
            target.ExitPortalTPThreshold();
            trackedTargets.Remove(target);
        }
    }
    private void OnValidate()
    {
        //le agrego un bool a esto. Cosa de poder decidir si quiero que esten linkeados
        //especialmente para las situaciones de alternancia de portales, cuando tengo 3 puertas
        if (linkedPortals)
        {
            if (linkedPortalTP != null)
            {
                linkedPortalTP.linkedPortalTP = this;
            }
        }
    }
}
