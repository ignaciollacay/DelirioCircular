using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject[] objectsToChangeMaterial;

    public Material finalMaterial;

    //Crea una varible de tipo string 
    string array = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject go in objectsToChangeMaterial)
            {
                go.GetComponent<MeshRenderer>().material = finalMaterial;

                /*
                Escribe en la consola un mensaje por cada item en el array. (No precisa de las lineas 12, 28 y 31)
                Debug.Log((go.ToString()) + "had material changed to " + finalMaterial.name);
                */

                //Agrega en la variable / cada elemento del array es nombrado por su nombre / los agrega en la variable separando por comas.
                array += go.ToString() + ", ";
            }
            //Escribe en la consola un mensaje concatenando en una misma linea cada item del array / agregando el nombre del material.
            Debug.Log(array + " had their material changed to Material: " + finalMaterial.name);
        }
    }
}