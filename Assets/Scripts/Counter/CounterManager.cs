using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    //counter
    [SerializeField] bool debug = false;
    
    private int counter;
    public int Counter
    {
        get
        {
            return counter;
        }
        set
        {
            counter = value;

            if (debug)
            {
                Debug.Log("CounterManager count is " + counter);
            }
        }
    }

    //aca empieza otro script. Quizas mejor separarlo. No se que diria SOLID.
    //Hole disable
    private void Start()
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
        StartCoroutine(HoleCoroutine());
    }

    public GameObject[] enable; // este hay que reemplazarlo por HoleEnable. Pero no quiero deslinkear la configuracion actual ahora
    public GameObject[] holeEnable;
    public GameObject[] disable;
    int arrayvalue = 0;
    //agrego esto por si tiene 1 o 2 portales.
    //En caso de que active 2 portales simultaneamente, puedo cambiar el valor a 2 en el inspector
    public int countermultiplier = 1;
    bool hole1()
    {
        if (counter == (1*countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool hole2()
    {
        if (counter == (2 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool hole3()
    {
        if (counter == (3 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool hole4()
    {
        if (counter == (4 * countermultiplier))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private IEnumerator HoleCoroutine()
    {
        yield return new WaitUntil(hole1);
        //HoleEnable();
        HoleDisable();
        yield return new WaitUntil(hole2);
        HoleEnable();
        HoleDisable();
        yield return new WaitUntil(hole3);
        HoleEnable();
        HoleDisable();
        yield return new WaitUntil(hole4);
        HoleEnable();
        HoleDisable();
        //El for each lo puedo reemplazar con el HoleEnable(), linkeando los objetos en una misma jerarquia, para que sea un objeto solo del array y no multiples objetos (no se si es posible igual)
        foreach (GameObject goEnable in enable)
        {
            goEnable.SetActive(true);
        }
    }
    void HoleDisable()
    {
        disable[arrayvalue].SetActive(false);
        arrayvalue++;
        Debug.Log("Arrayvalue: " + arrayvalue);
    }
    void HoleEnable()
    {
        holeEnable[arrayvalue].SetActive(true);
    }
    /*
    private void Update()
    {
        if (counter == 2)
        {
            disable[arrayvalue].SetActive(false);
            arrayvalue++;
        }
        if (counter == 4)
        {
            disable[arrayvalue].SetActive(false);
            arrayvalue++;
        }
        if (counter == 6)
        {
            disable[arrayvalue].SetActive(false);
            arrayvalue++;
        }
        if (counter == 8)
        {
            disable[arrayvalue].SetActive(false);

            foreach (GameObject goEnable in enable)
            {
                goEnable.SetActive(true);
            }
        }
    }
    */
}
