using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Start()
    {
        DisableCursor();
    }

    public void EnableCursor()
    {
        Cursor. lockState = CursorLockMode.None;
        Cursor. visible = true;
    }
    
    public void DisableCursor()
    {
        Cursor. lockState = CursorLockMode.Locked;
        Cursor. visible = false;
    }
}
