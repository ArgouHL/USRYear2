using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIMove : MonoBehaviour
{
    [SerializeField]
    protected CanvasGroup canvasGroup;

    [SerializeField]
    protected RectTransform showPos, hidePosL, hidePosR;

    [SerializeField]
    protected float duration;

    [SerializeField]
    protected LeanTweenType inType,outType;

    [SerializeField] private bool isShowing;
    public void Show()
    {
        if (isShowing)
            return;
        isShowing = true;
        LeanTween.move(canvasGroup.gameObject, showPos.position, duration).setEase(inType).setOnComplete(() =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        });
    }

    public void hide()
    {
        if (!isShowing)
            return;
        isShowing = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        LeanTween.move(canvasGroup.gameObject, hidePosL.position, duration).setEase(outType);
    }



}
