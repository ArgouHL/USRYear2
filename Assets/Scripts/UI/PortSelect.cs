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


    public void Start()
    {
        SetPort();
    }

    private void SetPort()
    {
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
       

    }

    public void ShowTargetPort(StageDataObj stageData)
    {
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
        if (SelectedStage != null)
        {
            LevelLoader.NewGame(SelectedStage);
            //Load Scene

        }
        else
            Debug.Log("no Stage select");
    }
}
