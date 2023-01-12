using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHolePiso : MonoBehaviour
{
    private GameObject rabbitHolePiso;
    private RabbitHolePiso rabbitHolePisoScript;

    void Start()
    {
        rabbitHolePiso = GameObject.Find("rabbitHolePiso");
        rabbitHolePisoScript = rabbitHolePiso.GetComponent<RabbitHolePiso>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rabbitHolePisoScript.GetComponent<Collider>().enabled = false;
        }
    }
}

