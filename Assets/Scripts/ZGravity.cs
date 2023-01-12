using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class ZGravity : MonoBehaviour
{
    //asi andaba antes de cambiar el First Person Controller por el del Portal
    //creo que igual habia una mejor manera y mucho mas facil. Me suena lo aprendi durnate virtuality
    //no es global phyiscs no? o ZgravityObj script? Habria de checkear por fechas
    /*
    private FirstPersonController FPC;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FPC = other.gameObject.GetComponentInParent<FirstPersonController>();
            
            FPC.m_GravityMultiplier = -0.04f;
            FPC.m_StickToGroundForce = -0.03f;
        }
    }
    */
    private FPSController FPC;

    //agrego esto para no sacar el componente 11/4/21
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && (isActive == true))
        {
            FPC = other.gameObject.GetComponentInParent<FPSController>();

            FPC.gravity = 0.1f;
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
