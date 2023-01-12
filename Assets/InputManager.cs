using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [Header("FOV Settings")]
    [SerializeField] Transform maskFOV90;
    [SerializeField] Transform maskFOV100;
    [SerializeField] Transform maskFOV110;
    [SerializeField] Transform maskFOV120;
    [SerializeField] Transform masks;
    [SerializeField] Camera mainCamera;

    [Header("Reset Game")]
    [SerializeField] string scene0Name = "Magma01_P0";
    [SerializeField] Transform playerPos;
    public bool autoReset = true;
    public int autoResetTime = 100;
    private Vector3 oldPos;
    private Vector3 newPos;

    void Start()
    {
        StartCoroutine(PlayerNotMovingTimer());
        if(autoReset == true)
        {
            StartCoroutine(PlayerLeftTheGame());
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            mainCamera.fieldOfView = 45;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCamera.fieldOfView = 90;
            masks.position = maskFOV90.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainCamera.fieldOfView = 100;
            masks.position = maskFOV100.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mainCamera.fieldOfView = 110;
            masks.position = maskFOV110.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mainCamera.fieldOfView = 120;
            masks.position = maskFOV120.position;
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(scene0Name, LoadSceneMode.Single);
    }

    bool PlayerHasNotMoved()
    {
        if (oldPos == newPos)
        {
            // Player in same position as before
            Debug.Log("Player in same position as before:" + oldPos + ", " + newPos);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator PlayerNotMovingTimer()
    {
        oldPos = playerPos.position;
        Debug.Log("NEW POS: "+ oldPos);
        yield return new WaitForSeconds(autoResetTime);
        newPos = playerPos.position;
        Debug.Log("NEW POS: "+ newPos);
        StartCoroutine(PlayerNotMovingTimer());
    }
    IEnumerator PlayerLeftTheGame()
    {
        yield return new WaitUntil(PlayerHasNotMoved);
        ResetGame();
    }
}
