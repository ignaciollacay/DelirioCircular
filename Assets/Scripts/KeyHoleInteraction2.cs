using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoleInteraction2 : MonoBehaviour
{
    private CharacterController characterController;
    //public GameObject thePlayer;
    //public Transform teleportTarget;

    //private LookAt lookAt;

    //public float speed;

    public float heightEnter = 0f;
    public float heightExit = 1.7f;
    public float skinWidthExit = 0.08f;
    public float skinWidthEnter = 0.025f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.height = heightEnter;
            characterController.skinWidth = skinWidthEnter;

            //float step = speed * Time.deltaTime;
            //thePlayer.transform.position = Vector3.Lerp(thePlayer.transform.position, teleportTarget.transform.position, step);

            //thePlayer.transform.position = teleportTarget.transform.position;
            //lookAt = other.gameObject.GetComponent<LookAt>();
            //lookAt.enabled = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterController = other.gameObject.GetComponent<CharacterController>();
            characterController.height = heightExit;
            characterController.skinWidth = skinWidthExit;
        }
    }
}
/*
{
    //public CharacterController characterController;
    public float heightCrouch = 1f;
    public float heightStand = 1.7f;
    public float skinWidthCrouch = 0.08f;
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        //characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        heightStand = 0f;
        skinWidthCrouch = 0.025f;

        thePlayer.characterController = gameObject.GetComponent<CharacterController>();
        thePlayer.characterController.height = heightCrouch;
        thePlayer.characterController.skinWidth = skinWidthCrouch;
    }
}
*/