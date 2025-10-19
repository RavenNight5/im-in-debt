using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrLose : MonoBehaviour
{
    public CanvasGroup PanelLose;
    private CanvasGroup PanelText;

    public TMP_Text LoseText;
    public TMP_Text PromptKey;

    [SerializeField] Button button;

    public List<string> LoseLines = new List<string>();

    private int currentLoseLine = 0;

    public float textFadeTime = 0.75f;

    void Start()
    {
        button.Select();

        PanelLose.gameObject.SetActive(false);
        PanelLose.alpha = 0.0f;
    }

    public void Activate()
    {
        PanelLose.gameObject.SetActive(true);
        PanelLose.DOFade(1.0f, 1.0f);
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
        PanelText.DOFade(0.0f, textFadeTime);

        StartCoroutine(waitfade(textFadeTime, PanelText, LoseText, LoseLines[currentLoseLine]));

        if (currentLoseLine < LoseLines.Count - 1)
        {
            currentLoseLine++;
        }
        else
        {
            button.gameObject.SetActive(false);
            StartCoroutine(waittorestart());


        }
    }
    IEnumerator waittorestart()
    {
        yield return new WaitForSeconds(1);

        PanelText.DOFade(0.0f, 1.2f);
        PromptKey.DOFade(0.0f, 1.2f);

        RestartDay();
    }
    IEnumerator restartday()
    {
        yield return new WaitForSeconds(1.3f);

        //SceneManager.LoadScene("Game", LoadSceneMode.Single);
        print("Restarting Day...");
    }
    private void RestartDay()
    {
        StartCoroutine(restartday());
    }
}
