using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class ZGravity2 : MonoBehaviour
{
    private FirstPersonController FPC;
    //agrego esto para no sacar el componente 11/4/21
    public bool isActive = false;

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (isActive == true))
        {
            FPC = other.gameObject.GetComponentInParent<FirstPersonController>();
            //FPC.m_GravityMultiplier = 0.01f;
            //FPC.m_StickToGroundForce = 0.01f;
        }
    }
}


    /*
    public GameObject Trigger;
    private GameObject FPSController;


    private FirstPersonController firstPersonController;
    

    // Start is called before the first frame update
    void Start()
    {
        firstPersonController = GetComponent<m_StickToGroundForce>();
    }

    private void OnTriggerEnter(Collider other)
        {
        if (other.tag == "Player")
        public float m_StickToGroundForce = 0.01f;
}
            
    

                //m_StickToGroundForce
                //m_GravityMultiplier
        }

    // Update is called once per frame
    void Update()
    {
 


    private FirstPersonController FPCScript;

    void Start()
    {
        fPSController = GameObject.Find("FPSController");
        FPCScript = fPSController.GetComponent<FirstPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FPCScript.GetComponent<>
        }
    }
}
}
          */