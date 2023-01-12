using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTimelineCounter : MonoBehaviour
{

    [SerializeField] bool debug = false;

    public CounterManager counterManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (debug)
            {
                Debug.Log("Player entered trigger" + gameObject.name, gameObject);
            }

            counterManager.Counter++;

            if (debug)
            {
                Debug.Log("Counter is " + counterManager.Counter);
            }
        }
    }
}
