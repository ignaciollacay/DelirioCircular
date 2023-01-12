using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportTarget : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject playerClone { get; set; }
    public Vector3 previousOffsetFromPortalTP { get; set; }

    public virtual void PortalTeleport (Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
    }
    public virtual void EnterPortalTPThreshold()
    {
        if (playerClone == null)
        {
            playerClone = Instantiate(playerObject);
            playerClone.transform.parent = playerObject.transform.parent;
            playerClone.transform.localScale = playerObject.transform.localScale;
        }
        else
        {
            playerClone.SetActive(true);
        }
    }

    public virtual void ExitPortalTPThreshold()
    {
        playerClone.SetActive(false);
    }
}
