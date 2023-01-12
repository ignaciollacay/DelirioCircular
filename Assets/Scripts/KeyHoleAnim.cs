using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHoleAnim : MonoBehaviour
{
    //este script va en el player
    //activa la animacion
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("PlayAnim", true);
        }
    }
}
