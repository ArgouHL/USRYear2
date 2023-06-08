using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameFade : MonoBehaviour
{
    public static GameFade instance;


    [SerializeField] private CanvasGroup fadeUI, week;
    [SerializeField] private TMP_Text weekText;
    [SerializeField] private float fadeInDuration = 1;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else

            instance = this;
    }


    private void Start()
    {
        LeanTween.delayedCall(1, FadeIn);
    }

    private void FadeIn()
    {
        weekText.text = SelfCodeHelper.GetWeek(StageControl.instance.week);
        LeanTween.value(0, 1, fadeInDuration).setOnUpdate((float val) => week.alpha = val)
            .setOnComplete(() =>
            LeanTween.delayedCall(1, () =>
             LeanTween.value(1, 0, fadeInDuration).setOnUpdate((float val) => fadeUI.alpha = val)
             .setOnComplete(() =>
             {
                 fadeUI.interactable = false;
                 fadeUI.blocksRaycasts = false;
                
             }
             )));
    }

    public void FadeOut(float duration)
    {
        fadeUI.interactable = true;
        fadeUI.blocksRaycasts = true;
        week.alpha = 0;
        LeanTween.value(0, 1, duration).setOnUpdate((float val) => fadeUI.alpha = val);
    }
}
