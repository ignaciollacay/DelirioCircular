using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counter++;
            Debug.Log("Counter is " + counter);
        }
    }
}
