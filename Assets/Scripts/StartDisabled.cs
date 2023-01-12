using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisabled : MonoBehaviour
{
    [SerializeField] bool disableOnStart = true;
    // Start is called before the first frame update
    void Start()
    {
        if (disableOnStart)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
