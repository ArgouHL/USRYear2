using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PortSelect : MonoBehaviour
{
    private StageDataObj SelectedStage;


    [SerializeField] private CanvasGroup buttons;
    [SerializeField] private CanvasGroup InfoUI;

    [SerializeField] private TMP_Text portName;
    [SerializeField] private TMP_Text portGoodTypes;
    [SerializeField] private TMP_Text portTarget;
    [SerializeField] private TMP_Text portInfo;

    [SerializeField] private RectTransform port2, port3;

    [SerializeField] private TMP_Text nowMonth;
    [SerializeField] private TMP_Text nowMoney;
    [SerializeField] private CanvasGroup state;
    public void Start()
    {
        SetPort();
        
    }

    private void ShowData()
    {
        state.alpha = 1;
        nowMonth.text = SelfCodeHelper.GetMonth(StageControl.currentMonth);
        nowMoney.text = PlayerDataControl.instance.playerData.Player_Money.ToString();
    }

    private void SetPort()
    {

        nowMonth.text = SelfCodeHelper.GetMonth(StageControl.currentMonth);
        nowMoney.text = PlayerDataControl.instance.playerData.Player_Money.ToString();

        if (PlayerDataControl.instance.playerData.normalOpen)
            port2.gameObject.SetActive(true);
        else
            port2.gameObject.SetActive(false);

        if (PlayerDataControl.instance.playerData.hardOpen)
            port3.gameObject.SetActive(true);
        else
            port3.gameObject.SetActive(false);
    }

    public void ShowPorts()
    {
        buttons.alpha = 1;
        buttons.interactable = true;
        buttons.blocksRaycasts = true;
        SetPort();

        ShowData();
    }

    public void ShowTargetPort(StageDataObj stageData)
    {
        SfxControl.instance.PlayClick();
        SelectedStage = stageData;
        InfoUI.alpha = 1;
        InfoUI.interactable = true;
        InfoUI.blocksRaycasts = true;
        portTarget.text = stageData.Cost.ToString();
        portName.text = stageData.PortName;
        portGoodTypes.text = stageData.StageGoodsString();
        portInfo.text = stageData.Info;
    }

    public void HidePortInfo()
    {
        InfoUI.alpha = 0;
        InfoUI.interactable = false;
        InfoUI.blocksRaycasts = false;
    }

    public void SelectStagePortAndStartGame()
    {
        SfxControl.instance.PlayClick();
        if (SelectedStage != null)
        {

            MusicControl.instance.SoftStopBGM();
            GameFade.instance.FadeOut(1f);
            LeanTween.delayedCall(1.2f,()=>LevelLoader.NewGame(SelectedStage));
            //Load Scene

        }
        else
            Debug.Log("no Stage select");
    }
}
