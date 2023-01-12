using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZGravityObj : MonoBehaviour
{
    public float FloatStrenght;
    public float RandomRotationStrenght;
    //pruebo desactivar esto temporalmente, para Prototipo inicio PAV4. Fecha hoy: 11/4/21
        //igual es un desastre que miles de objetos esten cambiando las global phyisics properties. 
        // en todo caso, solo 1 objeto en RH deberia triggerear esto, mientras este en RH.
    /*
    void Example()
    {
        Physics.gravity = new Vector3(0, 5f, 0);
    }
    */
    void Update()
    {
        transform.GetComponent<Rigidbody>().AddForce(Vector3.up * FloatStrenght);
        transform.Rotate(RandomRotationStrenght, RandomRotationStrenght, RandomRotationStrenght);
    }
}

/*
    Start is called before the first frame update
void Start()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
