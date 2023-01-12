using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoudiniClick : MonoBehaviour
{
    public GameObject[] enable;
    public GameObject[] disable;
    private bool _isInsideTrigger = false;

    void Start()
    {
        for (int i = 0; i < enable.Length; i++)
        {
            enable[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
        }
        if (_isInsideTrigger && Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < enable.Length; i++)
            {
                enable[i].SetActive(true);
            }
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
        }
    }
    /*
    void Update()
    {
        if (_isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < enable.Length; i++)
                {
                    enable[i].SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < enable.Length; i++)
            {
                enable[i].SetActive(false);
            }
        }
    }
    */

    /*
private void OnTriggerEnter(Collider other)
{
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(0))
            for (int i = 0; i < enable.Length; i++)
            {
                enable[i].SetActive(true);
            }
    }

    {
        if (other.tag == "Player")
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(false);
            }
    }
}
*/
}
