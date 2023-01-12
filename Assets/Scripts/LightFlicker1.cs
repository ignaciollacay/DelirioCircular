using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker1 : MonoBehaviour
{
    private Light _light;
    private Material _material;

    public Material MaterialPantallaPrendida;
    public Material MaterialPantallaFlicker;
    public Material MaterialPantallaApagada;

    public float minTime = 0.01f;
    public float maxTime = 0.5f;
    public float minInt = 0.1f;
    public float maxInt = 0.5f;

    void Start()
    {
        _light = GetComponent<Light>();
        //_material = GetComponent<Renderer>().material;
        
        StartCoroutine(FlickerLight());
        StartCoroutine(FlickerMaterial());
    }

    private IEnumerator FlickerLight()
    {
        yield return new WaitForSeconds(Random.Range(0.01f, 1));
        _light.intensity = (Random.Range(0.1f, 0.5f));

        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        _light.intensity = (Random.Range(minInt, maxInt));

        StartCoroutine(FlickerLight());
    }
    //todo esto es porque no puedo hacer que el emission oscile junto al intensity. La solucion asi seria agrandar el rango
    bool LowIntensity()
    {
        if ((_light.intensity <= 0.19f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool MidIntensity()
    {
        if ((_light.intensity < 0.4f) && (_light.intensity > 0.19f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool HighIntensity()
    {
        if (_light.intensity >= 0.4f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator FlickerMaterial()
    {
        yield return new WaitUntil(LowIntensity);
        GetComponentInChildren<Renderer>().material = MaterialPantallaApagada;
        yield return new WaitUntil(MidIntensity);
        GetComponentInChildren<Renderer>().material = MaterialPantallaFlicker;
        yield return new WaitUntil(HighIntensity);
        GetComponentInChildren<Renderer>().material = MaterialPantallaPrendida;


        //_material.DisableKeyword("_EMISSION");
        //Color Colour = new Color(0.1f, 0.1f, 0.1f);
        //_material.SetColor("_EMISSION", Colour);

        //yield return new WaitWhile (MidIntensity);
        //_material.EnableKeyword("_EMISSION");
        //_material.SetColor("_EMISSION", new Color(0.7f, 0.7f, 0.7f));
        //GetComponentInChildren<Renderer>().material = MaterialPantallaFlicker;

        StartCoroutine(FlickerMaterial());
    }
}
