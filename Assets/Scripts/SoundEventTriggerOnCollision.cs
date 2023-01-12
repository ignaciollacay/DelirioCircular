using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEventTriggerOnCollision : MonoBehaviour
{
    //https://www.fmod.com/resources/documentation-unity?version=2.0&page=game-components.html
    //revisar este link, 4.2.5, parece que el Componente de FMOD StudioEventEmmiter va en el objeto, solo hay que referenciar al componente y decirle las condiciones de play&stop. 
    //escribi mucho codigo de mas al emular el Component de FMOD a mi manera con codigo.

    //Declarar variables del path del FMOD SoundEvent, de manera publica, a traves del Inspector (permite mas versatilidad al script que definiendo manualmente el path con lineas 27 a 29)
    [FMODUnity.EventRef]
    public string CierreEvent = "";
    [FMODUnity.EventRef]
    public string AperturaEvent = "";

    //Declarar instancias de FMOD SoundEvent para poder reproducir sonidos de apertura y cierre de la puerta por codigo
    FMOD.Studio.EventInstance Cierre;
    FMOD.Studio.EventInstance Apertura;

    //
    Rigidbody cachedRigidBody;

    //Variable para saber si la puerta esta habilitada para abrirse o no. Con el fin de reproducir el sonido de locked.
    private bool _isLocked;

    //Esta condicional me permite que solo se active el sonido de cerrado cuando la puerta haya sido abierta. 
    //Esto arregla el problema de que se active el sonido de cerrado sin haber sido abierta, como cuando empieza el juego, que el door esta en el collider.
    private bool _isOpen = false;

    void Start()
    {
        //Esto es necesario para generar asignar los atributos 3D del sound event.
        cachedRigidBody = GetComponent<Rigidbody>();

        /*
        //Crear instancias de FMOD SoundEvent, definiendo  el path del sound event de manera manual y privada, con lo cual no requiere de variable publica (lineas 7 a 11)
        Cierre = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/PB_Puerta/Cierre (2D)");
        Apertura = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/PB_Puerta/Apertura");
        */

        //Crear instancias de FMOD SoundEvent, definiendo el path del sound event utilizando el string path definido por la variable publica
        Cierre = FMODUnity.RuntimeManager.CreateInstance(CierreEvent);
        Apertura = FMODUnity.RuntimeManager.CreateInstance(AperturaEvent);

        //Toma el valor del door interaction script
        _isLocked = GetComponentInParent<doorInteraction>()._isLocked;
        //Debug.Log("door state " + _isLocked);
    }
    
    //Detecta cuando algo entra en contacto con el collider de la cerradura...
    private void OnTriggerEnter(Collider other)
    {
        //si lo que entra en contacto es el objeto taggeado (la puerta)...
        if ((other.tag == "Door") && (_isOpen == true))
        {
            //Debug.Log("Door entered doorSFX collider: " + gameObject.name, gameObject);

            //Asignar atributos 3d al evento de sonido
            Cierre.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
            //Reproducir FMOD Sound Event del int ("event:/Fx/2C_Puerta/Ext/Cierre")
            Cierre.start();

            //Debug.Log(Cierre + "sound event played from " + gameObject.name, gameObject);

            _isOpen = false;
            //Debug.Log("Door is closed");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _isLocked = GetComponentInParent<doorInteraction>()._isLocked;

        if ((other.tag == "Door") && (_isLocked == false))
        {
            Debug.Log("Door exited doorSFX collider: " + gameObject.name, gameObject);

            _isOpen = true;
            Debug.Log("Door is open");

            Apertura.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject, cachedRigidBody));
            //Reproducir FMOD Sound Event de Apertura int ("event:/Fx/2C_Puerta/Ext/Apertura")
            Apertura.start();

            //Debug.Log(Apertura + "sound event played from " + gameObject.name, gameObject);
        }
    }
}
