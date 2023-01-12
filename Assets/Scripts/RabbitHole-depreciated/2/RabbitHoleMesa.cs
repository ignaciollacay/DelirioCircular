using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHoleMesa : MonoBehaviour
{
    private GameObject enemy;
    private Enemy enemyScript;

    void Start()
    {
        enemy = GameObject.Find("MesaRH");
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

