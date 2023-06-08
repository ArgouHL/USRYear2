using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBubbleControl : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private RectTransform bubbleBG;
    [SerializeField]
    private CanvasGroup ui;

    public void Show()
    {
        ui.alpha = 1;
    }
    public void Show(string[] texts)
    {
        AddTextAndChangeBubbleSize(texts);
        Show();
    }


    public void Show(string texts)
    {
        text.text = texts;
        Show();
    }

    public void Hide()
    {
        ui.alpha =0;
    }


    private void AddTextAndChangeBubbleSize(string[] texts)
    {
        string _text = "";
        int leght = 0;
        int line = 0;
        foreach (var text in texts)
        {
            _text += text;
            _text += "\n";
            line += 1;
            if (text.Length > leght)
                leght = text.Length;
        }
        _text = _text.TrimEnd('\r', '\n');


        float _width = 100;
        if (leght > 8)
        {
            _width = 100 + (leght - 8) * 10;
        }
        float _height = 40 + (line - 1) * 16;
        bubbleBG.sizeDelta = new Vector2(_width, _height);
        text.text = _text;
    }
}
