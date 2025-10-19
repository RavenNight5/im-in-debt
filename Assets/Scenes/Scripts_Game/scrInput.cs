using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr : MonoBehaviour
{
    public TMP_Text keyPressed;
    public TMP_Text keyboardPrompt;

    public List<String> allKeyPrompts = new List<String> { "Backspace", "a", "d", "w", "s", "Semicolon" };  // Space and enter are not included here as they are already in currentKeyPrompts
    public List<String> currentKeyPrompts = new List<String> { "Space", "Return" };

    private String keyToPress = "";

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
        }
    }


}
