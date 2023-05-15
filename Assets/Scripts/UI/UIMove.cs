using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    [SerializeField]
    protected CanvasGroup canvasGroup;

    [SerializeField]
    protected RectTransform showPos, hidePos;

    [SerializeField]
    protected float duration;

    [SerializeField]
    protected LeanTweenType inType,outType;

    public void Show()
    {
        LeanTween.move(canvasGroup.gameObject, showPos.position, duration).setEase(inType).setOnComplete(() =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        });
    }

    public void hide()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        LeanTween.move(canvasGroup.gameObject, hidePos.position, duration).setEase(outType);
    }



}
