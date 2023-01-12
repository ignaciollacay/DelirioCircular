using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShutSfx : MonoBehaviour
{
    //Declarar variable player para saber su posicion. Luego, poder calcular el dot product
    private GameObject player;
    
   //Declarar instancias de FMOD SoundEvent para poder reproducir sonidos de apertura y cierre de la puerta por codigo
   [FMODUnity.EventRef]
    public string CierreIntEvent = "";
    [FMODUnity.EventRef]
    public string CierreExtEvent = "";
    [FMODUnity.EventRef]
    public string AperturaIntEvent = "";
    [FMODUnity.EventRef]
    public string AperturaExtEvent = "";
    //
    FMOD.Studio.EventInstance CierreInt;
    FMOD.Studio.EventInstance CierreExt;
    FMOD.Studio.EventInstance AperturaInt;
    FMOD.Studio.EventInstance AperturaExt;
    //

    Rigidbody cachedRigidBody;

    //Variable para saber si la puerta esta habilitada para abrirse o no. Con el fin de reproducir el sonido de locked.
    private bool _isLocked;

    //Esta condicional me permite que solo se active el sonido de cerrado cuando la puerta haya sido abierta. 
    //Esto arregla el problema de que se active el sonido de cerrado sin haber sido abierta, como cuando empieza el juego, que el door esta en el collider.
    private bool _isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        cachedRigidBody = GetComponent<Rigidbody>();

        //Crear instancias de FMOD SoundEvent
        //ERROR: Esto esta asignando los eventos, por lo cual las variables publicas de los eventos no estan siendo utilizadas.
        CierreInt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Int/Cierre");
        CierreExt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Ext/Cierre");
        AperturaInt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Int/Apertura");
        AperturaExt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Ext/Apertura");

        //Toma el valor del door interaction script
        _isLocked = GetComponentInParent<doorInteraction>()._isLocked;
    }
    //Detecta cuando algo entra en contacto con el collider de la cerradura...
    private void OnTriggerEnter(Collider other)
    {
        //si lo que entra en contacto es el objeto taggeado (la puerta)...
        if ((other.tag == "Door") && (_isOpen == true))
        {
            //Debug.Log("Door entered doorSFX collider: " + gameObject.name, gameObject);

            Vector3 doorToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, doorToPlayer);

            if (dotProduct < 0f)
            {
                //Debug.Log("el dot product final es " + dotProduct);

                CierreExt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
                //Reproducir FMOD Sound Event del int ("event:/Fx/2C_Puerta/Ext/Cierre")
                CierreExt.start();

                //Debug.Log(CierreExtEvent + " sound event played from " + gameObject.name, gameObject);
            }
            else if (dotProduct > 0f)
            {
                //Debug.Log("el dot product final es " + dotProduct);

                CierreInt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
                //Reproducir FMOD Sound Event del ext ("event:/Fx/2C_Puerta/Int/Cierre")
                CierreInt.start();

                //Debug.Log(CierreIntEvent + " sound event played from " + gameObject.name, gameObject);
            }

            _isOpen = false;
            //Debug.Log("Door is closed");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _isLocked = GetComponentInParent<doorInteraction>()._isLocked;

        if ((other.tag == "Door") && (_isLocked == false))
        {
            //Debug.Log("Door exited doorSFX collider: " + gameObject.name, gameObject);

            Vector3 doorToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, doorToPlayer);
            
            if (dotProduct < 0f)
            {
                //Debug.Log("el dot product final es " + dotProduct);

                AperturaExt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
                //Reproducir FMOD Sound Event de Apertura int ("event:/Fx/2C_Puerta/Ext/Apertura")
                AperturaExt.start();

                //Debug.Log(AperturaExtEvent + " sound event played from " + gameObject.name, gameObject);
            }
            else if (dotProduct > 0f)
            {
                //Debug.Log("el dot product final es " + dotProduct);

                AperturaInt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
                //Reproducir FMOD Sound Event de Apertura ext ("event:/Fx/2C_Puerta/Int/Apertura")
                AperturaInt.start();

                //Debug.Log(AperturaIntEvent + " sound event played from " + gameObject.name, gameObject);
            }
            _isOpen = true;
            //Debug.Log("Door is open");
        }
    }
}

/*
 * {
    //Declarar variable player para saber su posicion. Luego, poder calcular el dot product
    public Transform player;
    
    //
    //[FMODUnity.EventRef]
    //public string CierreIntEvent = "";
    //
    FMOD.Studio.EventInstance CierreInt;
    //
    Rigidbody cachedRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        cachedRigidBody = GetComponent<Rigidbody>();
        CierreInt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Int/Cierre");
        CierreInt.start();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CierreInt.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
            CierreInt.start();
        }
        
    }
}
*/
        //BACKUP DEL SCRIPT CALCULANDO EL DOT PRODUCT. PERO NO SE AUN COMO HACER ANDAR UN SOUNDEVENT CREO 
        /*
        public class DoorShutSfx : MonoBehaviour
        {
            //Declarar variable player para saber su posicion. Luego, poder calcular el dot product
            public Transform player;

            //Declarar instancias de FMOD SoundEvent para poder reproducir sonidos de apertura y cierre de la puerta por codigo
            // /*
            private FMOD.Studio.EventInstance CierreInt;
            private FMOD.Studio.EventInstance CierreExt;
            private FMOD.Studio.EventInstance AperturaInt;
            private FMOD.Studio.EventInstance AperturaExt;
            //*

            //
            [FMODUnity.EventRef]
            public string CierreIntEvent = "";
            [FMODUnity.EventRef]
            public string CierreExtEvent = "";
            [FMODUnity.EventRef]
            public string AperturaIntEvent = "";
            [FMODUnity.EventRef]
            public string AperturaExtEvent = "";
            //
            FMOD.Studio.EventInstance CierreInt;
            FMOD.Studio.EventInstance CierreExt;
            FMOD.Studio.EventInstance AperturaInt;
            FMOD.Studio.EventInstance AperturaExt;
            //

            private bool _isInsideTrigger = false;

            // Start is called before the first frame update
            void Start()
            {
                CierreExt.start();
                //Crear instancias de FMOD SoundEvent
                /*
                CierreInt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Int/Cierre");
                CierreExt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Ext/Cierre");
                AperturaInt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Int/Apertura");
                AperturaExt = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Ext/Apertura");
                //*
            }
            private void OnTriggerEnter(Collider other)
            {
                if (other.tag == "Door")
                {
                    Vector3 doorToPlayer = player.position - transform.position;
                    float dotProduct = Vector3.Dot(transform.up, doorToPlayer);

                    if (dotProduct < 0f)
                    {
                        //Reproducir FMOD Sound Event del int ("event:/Fx/2C_Puerta/Ext/Cierre")
                        CierreExt.start();
                    }
                    else if (dotProduct > 0f)
                    {
                        //Reproducir FMOD Sound Event del ext ("event:/Fx/2C_Puerta/Int/Cierre")
                        CierreInt.start();
                    }
                }
            }
            private void OnTriggerExit(Collider other)
            {
                if (other.tag == "Door")
                {
                    Vector3 doorToPlayer = player.position - transform.position;
                    float dotProduct = Vector3.Dot(transform.up, doorToPlayer);

                    if (dotProduct < 0f)
                    {
                        //Reproducir FMOD Sound Event de Apertura int ("event:/Fx/2C_Puerta/Int/Apertura")
                        AperturaInt.start();
                    }
                    else if (dotProduct > 0f)
                    {
                        //Reproducir FMOD Sound Event de Apertura ext ("event:/Fx/2C_Puerta/Ext/Apertura")
                        AperturaExt.start();
                    }
                }
            }
        }
        */


//BACKUP DEL SCRIPT SIN CALCULAR DOT PRODUCT. IGUAL NO ESTABA ANDANDO
/*
public class DoorShutSfx : MonoBehaviour
{
    //Declarar instancias de FMOD SoundEvent para poder reproducir sonidos de apertura y cierre de la puerta por codigo
    private FMOD.Studio.EventInstance Cierre;
    private FMOD.Studio.EventInstance Apertura;

    private bool _isInsideTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        //Crear instancias de FMOD SoundEvent
        Cierre = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Ext/Cierre");
        Apertura = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/2C_Puerta/Ext/Apertura");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //_isInsideTrigger = true;
            Cierre.start();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //_isInsideTrigger = false;
            Apertura.start();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_isInsideTrigger == true)
        {
            Cierre.start();
            //closeDoorSfx.release();
        }
        else if (_isInsideTrigger == false)
        {
            Apertura.start();
        }
    }
}
*/
