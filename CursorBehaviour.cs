using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour {

    [SerializeField] Texture2D cursorTexture;
    [SerializeField] CursorMode cursormode = CursorMode.Auto;
    [SerializeField] CursorLockMode wantedMode = CursorLockMode.None;

    void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursormode);
    }

    void Update()
    {
        SetCursorStatee();
    }


    void SetCursorStatee()
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
}
