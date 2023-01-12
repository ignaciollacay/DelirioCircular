using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnim : MonoBehaviour
{
    private Animation _animation;
    private bool _isInsideTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
        }
    }

    void Update()
    {
        if (_isInsideTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animation.enabled = true;
            }
        }
        else
        {
            _animation.enabled = false;
        }
    }
}
/*
{
    private Animation _animation;

    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animation.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _animation.enabled = false;
        }
    }
}
*/
