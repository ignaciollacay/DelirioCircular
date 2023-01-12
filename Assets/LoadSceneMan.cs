using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMan : MonoBehaviour
{
    public string sceneName;
    private void Awake()
    {
        if ((SceneManager.GetSceneByName(sceneName).isLoaded) == false)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
