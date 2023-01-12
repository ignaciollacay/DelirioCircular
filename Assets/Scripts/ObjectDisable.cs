using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisable : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    void Start()
    {
        if (object1 == null)
        {
            object1 = GameObject.Find("defaultObject");
        }

        if (object2 == null)
        {
            object2 = GameObject.Find("defaultObject");
        }

        if (object3 == null)
        {
            object3 = GameObject.Find("defaultObject");
        }

        if (object4 == null)
        {
            object4 = GameObject.Find("defaultObject");
        }
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
        }
    }
}