using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using DG.Tweening;

public class scrWelcome : MonoBehaviour
{
    public TMP_Text WelcomeText;
    public TMP_Text PromptKey;

    [SerializeField] Button button;

    public List<string> WelcomeLines = new List<string>();

    private int currentWelcomeLine = 0;

    public float textFadeTime = 0.75f;

    void Start()
    {
        button.Select();

        WelcomeText.GetComponentInParent<CanvasGroup>().alpha = 0.0f;
    }



    public void ContinueCycle()
    {
        print("Continued...");

        // FadeTextInOut(WelcomeText.GetComponentInParent<CanvasGroup>());

        WelcomeText.GetComponentInParent<CanvasGroup>().DOFade(1.0f, textFadeTime);
        WelcomeText.SetText(WelcomeLines[currentWelcomeLine]);


        if (currentWelcomeLine < WelcomeLines.Count - 1)
        {
            currentWelcomeLine++;
        }
    }
}
