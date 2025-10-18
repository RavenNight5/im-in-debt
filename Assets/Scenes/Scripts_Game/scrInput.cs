using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr : MonoBehaviour
{
    public TMP_Text testText;
    //public InputActionAsset actions;
    //public InputAction keyboardAction;
    //public InputAction mouseAction;
    // Start is called before the first frame update
    void Start()
    {
        //actions = GetComponent<PlayerInput>().actions;

        //keyboardAction = actions.FindAction("KeyboardClick");
        //keyboardAction.Enable();

        //mouseAction = actions.FindAction("MouseClick");
        //mouseAction.Enable();

        //keyboardAction.performed -= ctx => keyPressed(ctx);
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.keyCode != KeyCode.None)
        {
            testText.SetText("Key Pressed: " + e.keyCode.ToString());
        }
    }


    //private void keyPressed(InputAction.CallbackContext ctx)
    //{
    //    var binding = ctx.action.GetBindingForControl(ctx.control);
    //    print($"Key Pressed: {binding}");

    //    if (keyboardAction.triggered)
    //    {
    //        testText.SetText("Keyboard Pressed");
    //    }
    //    if (mouseAction.triggered)
    //    {
    //        testText.SetText(mouseAction.GetBindingDisplayString());
    //    }


    //}
}
