using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;
//using UnityStandardAssets.Characters.ThirdPerson;

public class TimelinePlaybackManager : MonoBehaviour
{
    [Header("Timeline References")]
    public PlayableDirector playableDirector;

    [Header("Timeline Settings")]
    public bool playTimelineOnlyOnce;

    [Header("Player Input Settings")]
    public KeyCode interactKey;
    // Esto requiere un script vinculado al Character Controller, que desactive nombrando uno por uno los inputs (mover, crouch, jump)
    public bool disablePlayerInput = false;
    // Aca tengo que agregar otro bool para restaurar o no el disable player input after playback del timeline, sino el player se puede mover cuando termina la 1er timeline del keyhole interaction
    public bool disablePlayerInputAfterPlayback = false;

    //private ThirdPersonUserControl inputController; /**/ //este es su codigo
    private FPSController fpsController; /**/ //este es mi codigo pasado del suyo

    [Header("Player Timeline Position")]
    public bool setPlayerTimelinePosition = false;
    public Transform playerTimelinePosition;

    [Header("Trigger Zone Settings")]
    public GameObject triggerZoneObject;

    /* No se como ni si funciona. Desactivo hasta saber como funciona
    [Header("UI Interact Settings")]
    //esto sirve para activar el puntito que indique que es un interactable object
    public bool displayUI;
    public GameObject interactDisplay;
    */

    [Header("Player Settings")]
    public string playerTag = "Player";
    private GameObject playerObject;
    //private PlayerCutsceneSpeedController playerCutsceneSpeedController;

    private bool playerInZone = false;
    private bool timelinePlaying = false;
    private float timelineDuration;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag(playerTag);
        //inputController = playerObject.GetComponent<ThirdPersonUserControl> (); /**/ //este es su codigo
        fpsController = playerObject.GetComponent<FPSController>(); //este es mi codigo pasado del suyo
        //playerCutsceneSpeedController = playerObject.GetComponent<PlayerCutsceneSpeedController>();
        //ToggleInteractUI(false);
    }

    public void PlayerEnteredZone()
    {
        playerInZone = true;
        //ToggleInteractUI(playerInZone);
    }

    public void PlayerExitedZone()
    {
        playerInZone = false;
        //ToggleInteractUI(playerInZone);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone && !timelinePlaying) {

			var activateTimelineInput = Input.GetKey (interactKey);

			if (interactKey == KeyCode.None) {
				PlayTimeline ();
			} else {
				if (activateTimelineInput) {
					PlayTimeline ();
					//ToggleInteractUI (false);
				}
			}
		}
    }

    public void PlayTimeline()
    {
        if (setPlayerTimelinePosition)
        {
            SetPlayerToTimelinePosition();
        }

        if (playableDirector)
        {
            playableDirector.Play();
        }

        triggerZoneObject.SetActive(false);
        
        timelinePlaying = true;

        StartCoroutine(WaitForTimelineToFinish());
    }

    IEnumerator WaitForTimelineToFinish()
    {
        timelineDuration = (float)playableDirector.duration;
        
        // ME PARECE QUE ACA ESTA EL PROBLEMA. ESTA DESACTIVANDO EL INPUT SI O SI. CUANDO USA EL BOOL DISABLE PLAYER INPUT? EN TOGGLE INPUT QUE DESACTIVE?
        if (disablePlayerInput)
        {
            fpsController.inputAllowed = false;
        }

        yield return new WaitForSeconds(timelineDuration);
        // aca tengo que agregar un if con el bool de Enable Player Input After Playback 
        if (disablePlayerInputAfterPlayback == false)
        {
            fpsController.inputAllowed = true;
        }
        else
        {
            fpsController.inputAllowed = false;
        }


        if (!playTimelineOnlyOnce)
        {
            triggerZoneObject.SetActive(true);
        }
        else if (playTimelineOnlyOnce)
        {
            playerInZone = false;
        }

        timelinePlaying = false;
    }
    // aca lo que estamos tratando ahora  /**/ no fuciona esto asi.
    //o copiamos la manera en que el lo llama
    //o pasamos el fpsController.inputAllowed = true/false al Ienumerator WaitForTimelineToFinish() -- probamos esto primero y sino vemos la anterior
    /*
    void ToggleInput(bool newState)
    {
        if (disablePlayerInput)
        {
            //toggle inputAllowed = false in FPSController
            fpsController.inputAllowed = false;

            //playerCutsceneSpeedController.SetPlayerSpeed();
            //inputController.inputAllowed = newState;
        }
        else
        {

        }
    }
    */

    /* Desactivo hasta no aprender sobre como funciona el UI
    void ToggleInteractUI(bool newState)
    {
        if (displayUI)
        {
            interactDisplay.SetActive(newState);
        }
    }
    */

    //Esto no se si lo uso. Es para mover la posicion del player a la posicion de la timeline, para que no quede el Player en cualquier lado cuando interactua. 
    //Pero esta vinculado a la posicion del gameObject con este componente. Cosa que no se bien como lo hizo.
    void SetPlayerToTimelinePosition()
    {
        playerObject.transform.position = playerTimelinePosition.position;
        playerObject.transform.localRotation = playerTimelinePosition.rotation;
    }
}
