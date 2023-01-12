using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHole : MonoBehaviour
{
    //MAKE IT WORK. Virtuality

    public GameObject rabbitHolePiso;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rabbitHolePiso.GetComponent<Collider>().enabled = false;
        }
    }
}


/*
//30-10-20. no andaba este nuevo codigo o arruine el prefab? Solia andar hasta hace unos dias
//PRUEBA DE NUEVO CODIGO

{
private GameObject enemy;
private Enemy enemyScript;

void Start()
{
    enemy = GameObject.FindWithTag("FloorRH");
    enemyScript = enemy.GetComponent<Enemy>();
}

private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Player")
    { 
        enemyScript.GetComponent<Collider>().enabled = false;
    }
}
}

//ESTE ES EL CODIGO QUE ANDAba

{
    private GameObject enemy;
    private Enemy enemyScript;

    void Start()
    {
        enemy = GameObject.Find("FloorRH");
        enemyScript = enemy.GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyScript.GetComponent<Collider>().enabled = false;
        }
    }
}

/*
 * PRUEBAS DE CODIGO
 * {
    private void OnTriggerStay(Collider other)
    {
        GetComponent<Collider>().enabled = false;
    }
}
 * 
 *public CapsuleCollider playerCollider;
 * 
 * void Start()
 * {
 * playerCollider = this.GetComponent<CapsuleCollider>()
 * playerCollider.enabled = true;
 * }
 * 

{
    public BoxCollider floorCollider;

    // Start is called before the first frame update
    void Start()
    {
        floorCollider = this.GetComponent<BoxCollider>();
        floorCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
            floorCollider = this.GetComponent<BoxCollider>();
            floorCollider.enabled = false;
    }
}
 */

