using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepeating : MonoBehaviour
{
    public GameObject soundwave;
    public Transform spawnposition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InvokeRepeating("SpawnObject", 0, 0.0333f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CancelInvoke("SpawnObject");
        }
    }

    void SpawnObject()
    {
        Instantiate(soundwave, spawnposition.position, spawnposition.rotation);
    }
}



