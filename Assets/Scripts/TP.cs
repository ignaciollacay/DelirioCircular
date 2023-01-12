using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    //The variable for the teleport position
    public Transform teleportTarget;
    //The variable for the teleporting player
    private GameObject thePlayer;

    private void Start()
    {
        //Asignar a la variable el player, a partir del tag
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    //Setting the trigger for teleportation
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //The trigger makes one position equal to another
            thePlayer.transform.position = teleportTarget.transform.position;
        }
    }
}
