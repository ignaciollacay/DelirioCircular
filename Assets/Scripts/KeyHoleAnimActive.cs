using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class KeyHoleAnimActive : MonoBehaviour
{
    //este script en el collider de la puerta
    //es para detectar el collision y activa el animator en el pj 
    private GameObject thePlayer;
    private Animator _animator;
    private FirstPersonController FPC;

    private bool _isInsideTrigger = false;

    private void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");

        _animator = thePlayer.GetComponent<Animator>();
        _animator.enabled = false;
  
        FPC = thePlayer.GetComponent<FirstPersonController>();
        FPC.enabled = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isInsideTrigger = true;

            _animator = thePlayer.GetComponent<Animator>();
            _animator.enabled = true;

            _animator.SetBool("PlayAnim", true);

            FPC.enabled = false;
        }
    }

    void Update()
    {
        if (_isInsideTrigger)
        {
            //characterController = thePlayer.GetComponent<CharacterController>();
            //characterController.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                FPC = thePlayer.GetComponent<FirstPersonController>();
                FPC.enabled = true;

                _animator.SetBool("Exit", true);
                //_animator.enabled = false;

            }
        }
    }
}