using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;

public class scrLoad : MonoBehaviour
{
    [SerializeField] Image LoadBackground;

    void Awake()
    {
        LoadBackground.gameObject.SetActive(true);
        LoadBackground.DOFade(0.0f, 1.0f);
    }
}
