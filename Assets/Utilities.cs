using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public Transform[] startPos;
    public GameObject[] level;

    private GameObject thePlayer;
    private int counter = 0;

    private void Awake()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChangeLevel());
        StartCoroutine(ExitGame());
    }
    bool nextLevel()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool quitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private IEnumerator ExitGame()
    {
        yield return new WaitUntil(quitGame);
        QuitGame();
    }

    private IEnumerator ChangeLevel()
    {
        yield return new WaitUntil(nextLevel);
        LoadLevel();
        Teleport();
        StartCoroutine(ChangeLevel());
    }
    void Teleport()
    {
        thePlayer.transform.position = startPos[counter].transform.position;
    }
    void LoadLevel()
    {
        level[counter].SetActive(false);
        counter++;
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
