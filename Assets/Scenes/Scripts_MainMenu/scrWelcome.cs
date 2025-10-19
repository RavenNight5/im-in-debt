using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrWelcome : MonoBehaviour
{
    private CanvasGroup Welcome;
    public TMP_Text WelcomeText;
    public TMP_Text PromptKey;

    [SerializeField] Button button;

    public List<string> WelcomeLines = new List<string>();

    private int currentWelcomeLine = 0;

    public float textFadeTime = 0.75f;

    void Start()
    {
        button.Select();

        Welcome = GetComponent<CanvasGroup>();
        Welcome.alpha = 0.0f;
    }

    IEnumerator waitfade(float t, CanvasGroup cg, TMP_Text text=null, string textstr="")
    {
        yield return new WaitForSeconds(t);

        if (text != null)
        {
            text.SetText(textstr);
        }

        cg.DOFade(1.0f, t*1.3f);

    }

    public void ContinueCycle()
    {
        Welcome.DOFade(0.0f, textFadeTime);

        StartCoroutine(waitfade(textFadeTime, Welcome, WelcomeText, WelcomeLines[currentWelcomeLine]));

        if (currentWelcomeLine < WelcomeLines.Count - 1)
        {
            currentWelcomeLine++;
        }
        else
        {
            button.gameObject.SetActive(false);
            StartCoroutine(waittostart());
            

        }
    }
    IEnumerator waittostart()
    {
        yield return new WaitForSeconds(2);

        Welcome.DOFade(0.0f, 2.2f);
        PromptKey.DOFade(0.0f, 2.2f);

        StartGame();
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(2.3f);

        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    private void StartGame()
    {
        StartCoroutine(start());
    }
}
