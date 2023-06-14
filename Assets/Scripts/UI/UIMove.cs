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
        SfxControl.instance.PlayClick();
        if (isShowing)
            return;
        isShowing = true;
        LeanTween.move(canvasGroup.gameObject, showPos.position, duration).setEase(inType).setOnComplete(() =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        });
    }

    public void hideRight()
    {
        hide(Way.R);
    }


    public void hide(Way way)
    {
        SfxControl.instance.PlayClick();
        if (!isShowing)
            return;
        isShowing = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Transform w;
        switch(way)
        {
            default:
            case Way.L:
                 w = hidePosL;
                break;
            case Way.R:
                 w = hidePosR;
                break;
        }

        LeanTween.move(canvasGroup.gameObject, w.position, duration).setEase(outType);
    }



}
public enum Way { L, R }