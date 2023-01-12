using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveManagerBackup : MonoBehaviour
{
    GameObject[] DissolveMats;
    private Material dissolveMaterial;
    public float dissolveProgress = 0f;
    private GameObject thePlayer;
    private GameObject respawnPos;

    [SerializeField]
    public DissolveReset dissolveResetter;
    public ChangeLevel LevelChanger;
    public DissolveDuration dissolveDurationChanger;

    [SerializeField]
    bool dissolveReset = false;
    bool changeLevel = false;
    bool changeDissolveDuration = false;

    //Lerp Dissolve
    float minimum = 0.0F;
    float maximum = 0.8F;
    float t = 0.0f;
    float DissolveDuration = 20f;
    public float timeElapsed;

    //Lerp Dissolve Reset
    public float timeElapsed2;
    float DissolveResetDuration = 1f;

    public bool isResetting = false;

    private void Awake()
    {
        dissolveResetter = GameObject.FindGameObjectWithTag("DissolveReset").GetComponent<DissolveReset>();
        LevelChanger = GameObject.FindGameObjectWithTag("ChangeLevel").GetComponent<ChangeLevel>();
        dissolveDurationChanger = GameObject.FindGameObjectWithTag("DissolveDuration").GetComponent<DissolveDuration>();
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        respawnPos = GameObject.FindGameObjectWithTag("Respawn");
    }
    void Start()
    {
        dissolveMaterial = GetComponentInChildren<MeshRenderer>().material;
        dissolveMaterial.SetFloat("_DissolveProgress", dissolveProgress);
        StartCoroutine(LevelTwo());
        StartCoroutine(LevelTwoPartTwo());
    }
    
    IEnumerator LevelTwo()
    {
        yield return new WaitUntil(() => changeLevel);
        DissolveDuration = 4f;
        Debug.Log("Player reached level 2");
    }
    IEnumerator LevelTwoPartTwo()
    {
        yield return new WaitUntil(() => changeDissolveDuration);
        dissolveProgress = 0f;
        timeElapsed = 0f;
        timeElapsed2 = 0f;
        isResetting = true;
        Debug.Log("Player reached level 2 part 2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.anyKey)
        {
            if (dissolveReset == false && isResetting == false)
            {
                Dissolve();
            }
        }

        dissolveReset = dissolveResetter._DissolveReset;
        changeLevel = LevelChanger._LevelTwo;
        changeDissolveDuration = dissolveDurationChanger._LevelTwoPartTwo;

        if (dissolveProgress >= 0.8f)
        {
            thePlayer.transform.position = respawnPos.transform.position;
            thePlayer.transform.localRotation = respawnPos.transform.localRotation;
        }

        if (dissolveReset)
        {
            DissolveReset();
        }
    }

    void Dissolve()
    {
        dissolveMaterial = GetComponent<MeshRenderer>().material;
        dissolveMaterial.SetFloat("_DissolveProgress", dissolveProgress);

        timeElapsed2 = 0f;

        if (timeElapsed < DissolveDuration)
        {
            dissolveProgress = Mathf.Lerp(minimum, maximum, timeElapsed / DissolveDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            dissolveProgress = 1f;
        }
    }

    void DissolveReset()
    {
        dissolveMaterial = GetComponent<MeshRenderer>().material;
        dissolveMaterial.SetFloat("_DissolveProgress", dissolveProgress);

        timeElapsed = 0f;

        if (timeElapsed2 < DissolveResetDuration)
        {
            dissolveProgress = Mathf.Lerp(dissolveProgress, minimum, timeElapsed2 / DissolveResetDuration);
            timeElapsed2 += Time.deltaTime;
            isResetting = true;
        }
        else
        {
            dissolveProgress = 0f;
        }
        if (dissolveProgress == 0f)
        {
            isResetting = false;
        }
    }
}
