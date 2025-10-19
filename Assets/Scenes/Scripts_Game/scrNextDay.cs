using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrNextDay : MonoBehaviour
{
    public CanvasGroup NextDay;

    private CanvasGroup PanelText;

    public TMP_Text NextDayText;
    public TMP_Text PromptKey;

    [SerializeField] Button button;

    public List<string> NextDayLines = new List<string>();

    private int currentNextDayLine = 0;

    public float textFadeTime = 0.75f;

    void Start()
    {
        button.Select();

        NextDay.gameObject.SetActive(false);
        NextDay.alpha = 0.0f;
    }

    public void Activate()
    {
        NextDay.gameObject.SetActive(true);
        NextDay.DOFade(1.0f, 1.0f);

        ContinueCycle();
    }

    IEnumerator waitfade(float t, CanvasGroup cg, TMP_Text text = null, string textstr = "")
    {
        yield return new WaitForSeconds(t);

        if (text != null)
        {
            text.SetText(textstr);
        }

        cg.DOFade(1.0f, t * 1.3f);

    }

    public void ContinueCycle()
    {
        NextDay.DOFade(0.0f, textFadeTime);

        StartCoroutine(waitfade(textFadeTime, NextDay, NextDayText, NextDayLines[currentNextDayLine]));

        if (currentNextDayLine < NextDayLines.Count - 1)
        {
            currentNextDayLine++;
        }
        else
        {
            button.gameObject.SetActive(false);
            StartCoroutine(waittostartnextday());
        }
    }
    IEnumerator waittostartnextday()
    {
        yield return new WaitForSeconds(1);

        NextDay.DOFade(0.0f, 1.2f);
        PromptKey.DOFade(0.0f, 1.2f);

        StartNextDay();
    }
    IEnumerator startnextday()
    {
        yield return new WaitForSeconds(1.3f);

        print("Next Day Starting...");

        //SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    private void StartNextDay()
    {
        StartCoroutine(startnextday());
    }
}
