using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public string unloadScene;
    public string loadScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LoadScene();
            UnloadSceneAsync();
        }
    }
    void UnloadSceneAsync()
    {
        SceneManager.UnloadSceneAsync(unloadScene);
    }
    void LoadScene()
    {
        if ((SceneManager.GetSceneByName(loadScene).isLoaded) == false)
        {
            SceneManager.LoadScene(loadScene, LoadSceneMode.Additive);
        }
    }
}
