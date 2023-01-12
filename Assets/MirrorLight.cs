using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorLight : MonoBehaviour
{
    [SerializeField]Light _otherLight;

    // Start is called before the first frame update
    void Start()
    {
        //_light = GetComponent<Light>();
        this.GetComponent<Light>().intensity = _otherLight.GetComponent<Light>().intensity;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Light>().intensity = _otherLight.GetComponent<Light>().intensity;
    }
}
