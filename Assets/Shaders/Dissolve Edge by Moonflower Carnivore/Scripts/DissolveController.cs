using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    // Toggle between Diffuse and Transparent/Diffuse shaders
    // when space key is pressed

    Shader shader1;
    Shader shader2;
    Renderer rend;

    float vanishprogress = 1f;
    public float rate = 1f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Standard");
        shader2 = Shader.Find("MoonflowerCarnivore/Dissolve Edge");
    }

    void Update()
    {
        if (Input.GetKey("t"))
        {
            if (rend.material.shader == shader1)
            {
                rend.material.shader = shader2;

                vanishprogress = Mathf.MoveTowards(vanishprogress, 0f, Time.deltaTime * rate);
                rend.material.SetFloat("_Progress", vanishprogress);
            }
            else
            {
                rend.material.shader = shader1;
            }
        }
    }
}
/*{
    GameObject[] childrenGO;

    public Material[] dissolveMat;

    Material initialMaterial;
    

    void Awake()
    {
        children = GetComponentsInChildren<MeshRenderer>();
        foreach (GameObject child in children)
        {
            child.Material = initialMaterial;
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(0))
        {
            Material[] children = GetComponentsInChildren<Material>();
            children = dissolveMat;

            if (Input.GetMouseButtonDown(0))
            {
                children = initialMaterial;
            }
        }
    }
}*/

