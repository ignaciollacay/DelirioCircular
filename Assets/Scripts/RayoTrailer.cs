using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoTrailer : MonoBehaviour
{
    //Un Coroutine es una funcion que permite retrasar en el tiempo la ejecucion de la funcion asignada, sea por una determinada cantidad de tiempo o hasta que se cumpla otra condicion determinada.

    //Asigno el Light Component en una variable
    private Light _light;
    //Asigno la collision con el Trigger en una variable
    //private bool _isInsideTrigger;
    //Objeto para habilitar o deshabilitar durante el flash de luz
    public GameObject CuartoCasa;
    //Declarar instancia de FMOD SoundEvent
    private FMOD.Studio.EventInstance instance;
    
    void Start()
    {
        //Seleccionar el componente de la luz del objeto
        _light = GetComponent<Light>();
        //Inicio con intensidad luz nula
        _light.intensity = 0;

        //Desactivar la escena a aparecer al iniciar
        CuartoCasa.SetActive(false);

        //Activar el Coroutine para el Rayo       
        StartCoroutine(LightningStrike());
        //Activar el Coroutine para el FlashCasa
        StartCoroutine(FlashCasa());

        //Crear instancia de FMOD SoundEvent
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/Amb/Truenos/Truenos");
    }

    //Coroutine. Intervalo temporal e intensidad de la luz en Random.
    private IEnumerator LightningStrike()
    {
        //Ejecutar la funcion solo cuando el player este dentro del trigger
        //yield return new WaitUntil(InsideTrigger);
        yield return new WaitForSeconds(Random.Range(0.5f, 1));
        _light.intensity = (Random.Range(0.5f, 1.2f));
        //Reproducir instancia de FMOD SoundEvent
        instance.start();
        instance.release();
        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        _light.intensity = 0;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        _light.intensity = (Random.Range(0.2f, 0.6f));
        yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        _light.intensity = 0;
        yield return new WaitForSeconds(Random.Range(1.5f, 15));
        //este hace que se repita en loop
        StartCoroutine("LightningStrike");
    }

    //Activar una escena con el flash del rayo
    private IEnumerator FlashCasa()
    {
        //Ejecutar la funcion solo cuando el player este dentro del trigger
        //yield return new WaitUntil(InsideTrigger);
        //Activar la escena cuando el valor de intensidad de la luz sea mayor a "x"
        yield return new WaitUntil(GreaterThanIntensity);   //cuando el valor de intensidad de la luz es mayor...
        CuartoCasa.SetActive(true);    //...se activa la escena

        //Desactivar las luces del interior (corte de luz) 
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("LucesBeruti");
        foreach (GameObject go in gameObjectArray)
        {
            //go.GetComponent<Light>().enabled = false
            go.SetActive(false);
        }

        //Desactivar la escena cuando el valor de intensidad de la luz sea menor a "x"
        yield return new WaitWhile(GreaterThanIntensity);   //cuando el valor de intensidad de la luz sea menor a "x"...
        CuartoCasa.SetActive(false);   //...se desactiva la escena
        //Repetir en loop el Coroutine
        StartCoroutine("FlashCasa");
    }
    //Valores condicion para el coroutine del flash
    bool GreaterThanIntensity()
    {
        if (_light.intensity >= 0.9f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}