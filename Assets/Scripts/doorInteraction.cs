using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteraction : MonoBehaviour
{
    //Variable para controlar por codigo el animator component
    public Animator _animator;
    //Variable para saber si el player esta cerca de puerta para poder interactuar
    private bool _isInsideTrigger = false;

    //Variable para saber si la puerta esta habilitada para abrirse o no. Con el fin de reproducir el sonido de locked. Este valor define el valor en scripts SoundEventTriggerOnCollision y en DoorShutSfx.
    public bool _isLocked;

    [FMODUnity.EventRef]
    public string LockedEvent = "";

    FMOD.Studio.EventInstance Cerrado;

    Rigidbody cachedRigidBody;

    //Variable para el Occlusion Portal
    //OcclusionPortal occlusionPortal;

  
    // Start is called before the first frame update
    void Start()
    {
        //inicializacion de la variable "animator" al componente Animator del gameObject
        _animator = GetComponentInChildren<Animator>();

        //inicializacion de la variable "occlusion Portal" al componente Occlusion Portal del gameObject
        //occlusionPortal = GetComponent<OcclusionPortal>();
        //inicializacion del open state en falso (la puerta esta cerrada)
        //occlusionPortal.open = false;

        cachedRigidBody = GetComponent<Rigidbody>();

        Cerrado = FMODUnity.RuntimeManager.CreateInstance(LockedEvent);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            //Debug.Log("Player has entered door collider: " + gameObject.name, gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            //Debug.Log("Player has exited door collider: " + gameObject.name, gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //si el usuario esta adentro del trigger collider
        if ((_isInsideTrigger))
        {
            //si el usuario interactua con el click
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Player has interacted with door: " + gameObject.name, gameObject);

                //si la puerta no esta lockeada (se puede abrir)
                if (_isLocked == false)
                {
                    //cambiar el estado del occlusion portal a abierto
                    //occlusionPortal.open = true;

                    //abrir la puerta (ejecutar la animacion de abrir puerta)
                    _animator.SetBool("open", true);
                    Debug.Log("Door opened: " + gameObject.name, gameObject);
                }
                //si la puerta esta lockeada (no se puede abrir)
                else if (_isLocked == true)
                {
                    //mantener el estado del occlusion portal en cerrado
                    //occlusionPortal.open = false;

                    //mantener cerrada la puerta (el estado de la animacion de abrir sigue siendo falso/cerrado)
                    _animator.SetBool("open", false);
                    Debug.Log("Door locked: " + gameObject.name, gameObject);

                    //quiero reproducir el sonido de que esta cerrada, sin ejecutar el animator ya que sigue cerrada
                    //Asignar atributos 3d al evento de sonido
                    Cerrado.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
                    //Reproducir FMOD Sound Event del int ("event:/Fx/2C_Puerta/Ext/Cierre")
                    Cerrado.start();
                    //Debug.Log(Cerrado + "sound event played from " + gameObject.name, gameObject);
                }
            }
        }
        //si el usuario no esta adentro del trigger collider
        else
        {
            //mantener el estado del occlusion portal en cerrado
            //occlusionPortal.open = false;

            //mantener cerrada la puerta (el estado de la animacion de abrir sigue siendo falso/cerrado)
            _animator.SetBool("open", false);
            //Debug.Log("Player has left door collider (on Update)");
        }
    }
}
/*
//Version previa del script de Door Interaction, sin locked door ni occlusion portal
{
    //Variable para controlar por codigo el animator component
    private Animator _animator;
    //Variable para saber si el player esta cerca de puerta para poder interactuar
    private bool _isInsideTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetBool("open", true);
            }
        }
        else
        {
            _animator.SetBool("open", false);
        }
    }
}

    */
