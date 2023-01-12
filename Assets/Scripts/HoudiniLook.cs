using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoudiniLook : MonoBehaviour
{
    public bool triggerOnce = false;

    public bool debug = false;

    public MouseOver MouseOverTarget;

    //public Collider hole;
    public GameObject[] enable;
    public GameObject[] disable;

    bool mouseisOver = false;
    bool isInTrigger = false;



    bool hasTriggered = false;

    private void Enable()
    {
        foreach (GameObject goEnable in enable)
        {
            //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
            //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
            if (goEnable != null)
            {
                goEnable.SetActive(true);
            }
        }
        foreach (GameObject goDisable in disable)
        {
            //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
            //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
            if (goDisable != null)
            {
                goDisable.SetActive(false);
            }
        }
        if (debug)
        {
            Debug.Log("The Player is looking at the hole !");
        }
    }

    void Disable()
    {
        foreach (GameObject goEnable in enable)
        {
            //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
            //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
            if (goEnable != null)
            {
                goEnable.SetActive(false);
            }
        }
        foreach (GameObject goDisable in disable)
        {
            //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
            //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
            if (goDisable != null)
            {
                goDisable.SetActive(true);
            }
        }

        if (debug)
        {
            Debug.Log("The Player is no longer looking at the hole !");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInTrigger = false;
        }
    }

    private void Update()
    {
        if (triggerOnce && hasTriggered)
        {
            return;
        }


        if (MouseOverTarget.mouseIsOver)
        {
            Enable();
            //esto es para el trigger once
            hasTriggered = true;
        }
        else if (isInTrigger)
        {
            if (MouseOverTarget.mouseIsOver)
            {
                Enable();
                //esto es para el trigger once
                hasTriggered = true;
            }
        }
        else
        {
            Disable();
        }
    }
}
    /*
    private void Start()
        {
            foreach (GameObject goEnable in enable)
            {
                //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                if (goEnable != null)
                {
                    goEnable.SetActive(true);
                }
            }
            foreach (GameObject goDisable in disable)
            {
                //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                if (goDisable != null)
                {
                    goDisable.SetActive(false);
                }
            }
        }
        private void Update()
        {
            if (MouseOverScript.mouseIsOver)
            {

            }
        }
    }

        /*

        void OnMouseOver()
        {
            foreach (GameObject goEnable in enable)
            {
                //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                if (goEnable != null)
                {
                    goEnable.SetActive(true);
                }
            }
            foreach (GameObject goDisable in disable)
            {
                //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                if (goDisable != null)
                {
                    goDisable.SetActive(false);
                }
            }
            if (debug)
            {
                Debug.Log("The Player is looking at the hole !");
            }

            mouseisOver = true;
        }
        void OnMouseExit()
        {
            if (!isInTrigger)
            {
                foreach (GameObject goEnable in enable)
                {
                    //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                    //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                    if (goEnable != null)
                    {
                        goEnable.SetActive(false);
                    }
                }
                foreach (GameObject goDisable in disable)
                {
                    //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                    //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                    if (goDisable != null)
                    {
                        goDisable.SetActive(true);
                    }
                }

                mouseisOver = false;

                if (debug)
                {
                    Debug.Log("The Player is no longer looking at the hole !");
                }
            }
        }
        /*
        void OnTriggerEnter(Collider other)
        {
            if (mouseisOver)
            {
                if ((other.gameObject.tag == "Player"))
                {
                    foreach (GameObject goEnable in enable)
                    {
                        //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                        //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                        if (goEnable != null)
                        {
                            goEnable.SetActive(false);
                        }
                    }
                    foreach (GameObject goDisable in disable)
                    {
                        //recibo muchos console messages por Unassigned variables por error en prefab workflow. 
                        //Agrego un null check, pero en realidad quisiera que me avise si me falto referenciarlo si tengo bien armado el proyecto
                        if (goDisable != null)
                        {
                            goDisable.SetActive(true);
                        }
                    }

                    isInTrigger = true;

                    if (debug)
                    {
                        Debug.Log("The Player is inside hole Trigger !");
                    }
                }
            }
        }
    }
    */
