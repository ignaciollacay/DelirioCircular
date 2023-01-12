using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houdini : MonoBehaviour
{
    //me falta un bool para que sea interactuable on mouse click o no, con default en false
    public bool isInteractable = false;

    public GameObject[] enable;
    public GameObject[] disable;
    //  private bool istriggered = false;
    
    //String variable for debug message 
    //string array = "";

    //(opcional) un bool para que se desactive luego de ser usado, con default en en true
    void Start()
    {
        Debug.Log("Houdini triggered on Start: " + gameObject.name, gameObject);
        foreach (GameObject goEnable in enable)
        {
            //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
            //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
            if (goEnable != null)
            {
                goEnable.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.tag == "Player" && isInteractable == false)
            {
                Debug.Log("Player triggered: " + gameObject.name, gameObject);

                foreach (GameObject goEnable in enable)
                {
                    goEnable.SetActive(true);
                }

                foreach (GameObject goDisable in disable)
                {
                    goDisable.SetActive(false);
                }
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player") && (isInteractable == true))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Player interaction triggered: " + gameObject.name, gameObject);
                foreach (GameObject goEnable in enable)
                {
                    goEnable.SetActive(true);
                    Debug.Log("Enabled: " + goEnable.ToString());
                }
                foreach (GameObject goDisable in disable)
                {
                    goDisable.SetActive(false);
                    Debug.Log("Disabled: " + goDisable.ToString());
                }
            }
        }
    }
    //esto podria ser un bool con default en true
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.enabled = false;
        }
    }
}
/* BACKUP DEL SCRIPT ANTES DE PASAR A FOREACH LOOP
{
    //me falta un bool para que sea interactuable on mouse click o no, con default en false
    public bool isInteractable = false;

    public GameObject[] enable;
    public GameObject[] disable;
    //public GameObject[] meshrendererEnable;
    //public GameObject[] meshrendererDisable;
    //  private bool istriggered = false;
    
    //String variable for debug message 
    string array = "";

    //(opcional) un bool para que se desactive luego de ser usado, con default en en true
    void Start()
    {
        Debug.Log("Houdini triggered on Start: " + gameObject.name, gameObject);
        for (int i = 0; i < enable.Length; i++)
        {
            enable[i].SetActive(false);
            Debug.Log(gameObject.name + " disabled: " + enable[i].name, enable[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("Player triggered: " + gameObject.name, gameObject);
    {
        for (int i = 0; i < enable.Length; i++)
        {
            enable[i].SetActive(true);
            Debug.Log(gameObject.name + " enabled: " + enable[i].name, enable[i]);
        }
        
    }
    
    {
        if (other.tag == "Player")
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].SetActive(false);
                Debug.Log(gameObject.name + " disabled: " + enable[i].name, enable[i]);
            }
    }
    /*
    {
        if (other.tag == "Player")
            for (int i = 0; i < meshrendererEnable.Length; i++)
            {
                meshrendererEnable[i].GetComponent<Renderer>().enabled = true;
            }
    }
    {
        if (other.tag == "Player")
            for (int i = 0; i < meshrendererDisable.Length; i++)
            {
                meshrendererDisable[i].GetComponent<Renderer>().enabled = false;
            }
    }
    */ /*
    
}
//esto deberia de ser un bool con default en true
void OnTriggerExit(Collider other)
{
    if (other.tag == "Player")
    {
        this.enabled = false;
    }
}
}
*/