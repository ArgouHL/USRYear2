using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GoodSelect : MonoBehaviour
{
    private GoodType goodType;

    [SerializeField] private Image image;
    [SerializeField] private TMP_Text goodName;
    [SerializeField] private CanvasGroup ui;
    public void SetGood(GoodData data)
    {
        goodType = data.type;
        image.sprite = data.sprite;
        goodName.text = data.goodName;
    }



    public void SelectThisGood()
    {
        GameManagement.instance.SelectGood(goodType);
    }

    internal void Hide()
    {
        ui.alpha = 0.7f;
        ui.interactable = false;
    }

    internal void Show()
    {
        ui.alpha = 1;
        ui.interactable = true;
    }
}
