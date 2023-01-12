using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public bool mouseIsOver = false;

    void OnMouseOver()
    {
        mouseIsOver = true;
    }
    void OnMouseExit()
    {
        mouseIsOver = false;
    }
}
