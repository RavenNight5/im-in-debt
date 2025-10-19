using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    public TMP_Text keyPressed;
    public TMP_Text keyboardPrompt;
    public TMP_Text date;

    public GameObject nextDayPanel;

    public Slider attentionBar;

    public List<String> allKeyPrompts = new List<String> { "Backspace", "a", "d", "w", "s", "Semicolon" };  // Space and enter are not included here as they are already in currentKeyPrompts
    public List<String> currentKeyPrompts = new List<String> { "Space", "Return" };

    private String keyToPress = "Space";
    private String currentKeyPressed;

    public float attentionDecrement = 0.1f;
    public float attentionIncrement = 0.2f;

    public float regenMultiplier = 0.05f;

    public int waitRangeLOW = 2;
    public int waitRangeHigh = 6;

    private bool regenerateAttention = true;

    private bool keyHeld = false;

    private int currentDay = 1;
    private bool playing = false;

    private void Awake()
    {
        if (keyboardPrompt != null)
            keyboardPrompt.SetText(keyToPress);

        playing = true;

        StartCoroutine(waitrand(waitRangeLOW, waitRangeHigh));
    }

    IEnumerator waitrand(int low, int high)
    {
        int randwait = UnityEngine.Random.Range(low, high);
        print(randwait);
        yield return new WaitForSeconds(randwait);

        int rand = UnityEngine.Random.Range(0, currentKeyPrompts.Count);

        keyToPress = currentKeyPrompts[rand];

        if (keyboardPrompt != null)
        {
            keyboardPrompt.SetText("["+keyToPress.ToLower()+"]");
        }

        if (playing)
        {
            StartCoroutine(waitrand(waitRangeLOW, waitRangeHigh));
        }
        
    }
    
    void FixedUpdate()
    {
        if (regenerateAttention)
        {
            attentionBar.value += regenMultiplier;
        }

        if (attentionBar.value <= 0.0f && playing)  //COMPLETED DAY
        {
            playing = false;
            currentDay++;

            date.SetText($"<b><size=8>0{(1 + currentDay).ToString()}</size></b>\n/03/1989");

            nextDayPanel.GetComponent<scrNextDay>().Activate();
        }
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && e.keyCode != KeyCode.None && playing)
        {
            if (e.type == EventType.KeyDown && !keyHeld)
            {
                keyHeld = true;
                regenerateAttention = false;

                if (keyPressed != null)
                    keyPressed.SetText(e.keyCode.ToString());

                currentKeyPressed = e.keyCode.ToString();

                if (currentKeyPressed == keyToPress)
                {
                    attentionBar.value -= attentionDecrement;
                    print("Correct Key Pressed");
                }
                else
                {
                    attentionBar.value += attentionIncrement;
                    print("Wrong Key Pressed");
                }
            }
            else if (e.type == EventType.KeyUp)
            {
                keyHeld = false;
                regenerateAttention = true;
            }
        }
    }
}
