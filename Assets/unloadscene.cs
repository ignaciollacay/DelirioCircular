using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class unloadscene : MonoBehaviour
{
    bool UnloadScene = false;
    Scene ExpoTesteo05Part1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnloadScene = true;
        }
    }
    void SceneUnloader()
    {
        if (UnloadScene)
        {
            SceneManager.UnloadSceneAsync(ExpoTesteo05Part1);
        }
    }
}
