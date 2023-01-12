using UnityEngine;

public class MainCamera : MonoBehaviour {

    Portal[] portals;

    void Awake () {
        portals = FindObjectsOfType<Portal> ();
    }

    //este lo necesito solo si uso el RenderTexture Portal. Si no lo puedo sacar. Todo el script de hecho.
    void LateUpdate () {

        for (int i = 0; i < portals.Length; i++) {
            portals[i].Render ();
        }
    }
}