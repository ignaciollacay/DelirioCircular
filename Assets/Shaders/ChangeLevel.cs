using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public bool _LevelTwo = false;
    public GameObject RespawnPosition;

    private void Start()
    {
        StartCoroutine(LevelTwo());
    }
    
    IEnumerator LevelTwo()
    {
        yield return new WaitUntil(() => _LevelTwo);
        RespawnPosition.transform.position = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _LevelTwo = true;
        }
        else
        {
            _LevelTwo = false;
        }
    }
}
