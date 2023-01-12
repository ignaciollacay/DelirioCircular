using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
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
 * {
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && characterController.height == 1.7f))
        {
            characterController.height = 1f;
        }

        else if ((Input.GetKey(KeyCode.LeftControl) && characterController.height != 1.7f))
        {
            characterController.height = 1.7f;
        }
    }
}
*/
