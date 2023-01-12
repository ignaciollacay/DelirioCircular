using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatAlphaAnim : MonoBehaviour
{
    public float alphaDistanceMultiplier = 1;

    Color colorStart = Color.white;
    Color colorEnd = Color.white;

    float alphaStart = 0;
    float alphaEnd = 1;

    Renderer rend;

    private GameObject player;

    private bool insideTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();

        colorStart.a = alphaStart;
        colorEnd.a = alphaEnd;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            insideTrigger = true;
            Debug.Log("Player is inside MatAlphaAnim trigger" + gameObject.name, gameObject);
        }
    }

    //Empezar inicializando el IEnumerator
    //Cuando InsideTrigger == true, 
    //ejecutar void DecreaseAlpha()
    void Update()
    {
        if (insideTrigger)
        {
            //DecreaseAlpha();

            //calculo la distancia entre las propiedades de posicion de ambos objetos
            Vector3 doorToPlayer = player.transform.position - transform.position;
            //paso la distancia a un float value
            float distance = Vector3.Dot(transform.up, doorToPlayer);
            float relativeDistance = (distance / 18) * alphaDistanceMultiplier;
            //print("distance: " + relativeDistance);
            
            //a medida que la distancia aumenta, el alpha se reduce
            rend.material.color = Color.Lerp(colorStart, colorEnd, relativeDistance);

        }
    }
    /*
    void RelativePercentageDistanceRange()
    {
        float max = 18;
        float min = 0;
        float averageValue = (max + min)/2;

        float range = max - min;

        float relativePercentRange = 


    }*/

    /* IEnum + void
// Habria de tener un IEnumerator (Coroutine) con un wait until player is inside trigger to start decreasing Alpha
//IEnumerator StartDecreasingAlpha
void DecreaseAlpha()
{
    //calculo la distancia entre las propiedades de posicion de ambos objetos
    Vector3 doorToPlayer = player.transform.position - transform.position;
    //paso la distancia a un float value
    float distance = Vector3.Dot(transform.up, doorToPlayer);
    //a medida que la distancia aumenta, el alpha se reduce
    color.a = 5 * distance;
}

IEnumerator WaitForPlayerCollision()
{
    //calculo la distancia entre las propiedades de posicion de ambos objetos
    Vector3 doorToPlayer = player.transform.position - transform.position;
    //paso la distancia a un float value
    float distance = Vector3.Dot(transform.up, doorToPlayer);
    //a medida que la distancia aumenta, el alpha se reduce
    color.a = 5 * distance;
}
    */
}
