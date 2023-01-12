using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    float vanishprogress = 1f;
    public float rate = 1f;
    
    void Update()
    {
        if (Input.GetKey("t"))
        {
            Renderer rr = gameObject.GetComponent<Renderer>();     //wouldn't normally put getcomp in update!

            vanishprogress = Mathf.MoveTowards(vanishprogress, 0f, Time.deltaTime * rate);

            rr.material.SetFloat("_Progress", vanishprogress);
        }
    }
}

