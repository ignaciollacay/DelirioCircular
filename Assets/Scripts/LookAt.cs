using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject thePlayer;
    public Transform keyHole;

    void Update()
    {
        transform.LookAt(keyHole);
    }
}



/*
public class LookAt : MonoBehaviour
{
    public Transform keyHole;
    private bool _isInsideTrigger = false;
    //Input.GetKey(KeyCode.LeftControl

    private GameObject keyHoleDoor;
    private LookAt DoorColliderScript;

    // Start is called before the first frame update
    void Start()
    {
        //on enter trigger 
        //if IsTriggered && crouch ==true{
        keyHoleDoor = GameObject.Find("keyHoleDoor");
        DoorColliderScript = keyHoleDoor.GetComponent<LookAt>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInsideTrigger)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //_animation.enabled = true;
                transform.LookAt(keyHole);
            } 
        }
       
    }
}
*/