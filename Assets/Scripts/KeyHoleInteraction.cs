using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoleInteraction : MonoBehaviour
{
    public CharacterController characterController;
    public float heightCrouch = 1f;
    public float heightStand = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = heightCrouch;
        }

        else
        {
            characterController.height = heightStand;
        }
    }
}
/*
//The variable for the teleport (keyhole) position
public Transform keyHole;
    //The variable for the teleporting player
    public GameObject thePlayer;
    //The smoothness
    public float speed;

    /*
        //TELEPORT
    //Setting the trigger for teleportation
    private void OnTriggerEnter(Collider other)
    {
        //The trigger makes one position equal to another
        thePlayer.transform.position = keyHole.transform.position;
    }
    //Now i need to set a smooth transition. .. delta time / speed
    */
    /*
    //MOVE TOWaRDS
    void OnTriggerEnter(Collider other)
    {
        float step = speed * Time.deltaTime;
        thePlayer.transform.position = Vector3.MoveTowards(transform.position, keyHole.position, step);
    }
}
*/

/*
 {
    public CharacterController characterController;
    public GameObject keyHole;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.transform.position = Vector3.MoveTowards(keyHole.transform, characterController.position, step); m = 1f;
        }
    }
}

*/