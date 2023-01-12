using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveDoorOpen : MonoBehaviour
{
    public Collider colliderDisable;

    private void OnTriggerEnter(Collider other)
    {
        colliderDisable.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        colliderDisable.enabled = true;
    }

}
