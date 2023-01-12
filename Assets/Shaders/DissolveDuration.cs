using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveDuration : MonoBehaviour
{
    public bool _LevelTwoPartTwo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _LevelTwoPartTwo = true;
            Debug.Log("Level 2 part 2 bool " + _LevelTwoPartTwo);
        }
        else
        {
            _LevelTwoPartTwo = false;
        }
    }
}
