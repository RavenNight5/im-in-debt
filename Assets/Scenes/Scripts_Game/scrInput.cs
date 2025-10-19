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
    public List<String> currentKeyPrompts = new List<String> { "Space", "Return" };

    private String keyToPress = "";
    private String currentKeyPressed;

    private float attentionDecrement = 0.1f;
    
    public int waitRangeLOW = 2;
    public int waitRangeHigh = 6;

    private void Awake()
    {
        StartCoroutine(waitrand(waitRangeLOW, waitRangeHigh));
    }

    IEnumerator waitrand(int low, int high)
    {
        int randwait = UnityEngine.Random.Range(low, high);
        print(randwait);
        yield return new WaitForSeconds(randwait);

        int rand = UnityEngine.Random.Range(0, currentKeyPrompts.Count);

        keyToPress = currentKeyPrompts[rand];

        if (keyPressed != null)
        {
            keyboardPrompt.SetText(keyToPress);
        }

        StartCoroutine(waitrand(waitRangeLOW, waitRangeHigh));
    }
    
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


}
