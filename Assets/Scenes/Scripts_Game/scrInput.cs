using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    public TMP_Text keyPressed;
    public TMP_Text keyboardPrompt;

    public Slider attentionBar;

    public List<String> allKeyPrompts = new List<String> { "Backspace", "a", "d", "w", "s", "Semicolon" };  // Space and enter are not included here as they are already in currentKeyPrompts
    public List<String> currentKeyPrompts = new List<String> { "Space", "Enter" };

    private String keyToPress;
    private String currentKeyPressed;

    private float attentionDecrement = 0.1f;
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

        keyToPress = currentKeyPrompts[0];
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
            keyPressed.SetText(e.keyCode.ToString());
            currentKeyPressed = e.keyCode.ToString();

            if (currentKeyPressed == keyToPress)
            {
                attentionBar.value -= attentionDecrement;
                print("Correct Key Pressed");
            } else if (currentKeyPressed != keyToPress)
            {
                print("Wrong Key Pressed");
            }
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
