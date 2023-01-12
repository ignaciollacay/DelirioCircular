using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoudiniOnDisable : MonoBehaviour
{
    public GameObject[] disable;
    public GameObject[] enable;

    private void OnDisable()
    {
        Debug.Log("Houdini triggered: " + gameObject.name, gameObject);

        foreach (GameObject goDisable in disable)
        {
            goDisable.SetActive(false);
            Debug.Log("Houdini disabled: " + gameObject.name, gameObject);
        }

        foreach (GameObject goEnable in enable)
        {
            goEnable.SetActive(false);
            Debug.Log("Houdini enabled: " + gameObject.name, gameObject);
        }
    }
}
