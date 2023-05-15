using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PortSelect : MonoBehaviour
{
    private StageDataObj SelectedStage;


    [SerializeField] private CanvasGroup buttons;
    [SerializeField] private CanvasGroup InfoUI;
    [SerializeField] private Image portImage;
    [SerializeField] private TMP_Text portName;
    [SerializeField] private TMP_Text portGoodTypes;
    [SerializeField] private TMP_Text portInfo;
    [SerializeField] private RectTransform port2,port3;



    public void ShowPorts()
    {
        buttons.alpha = 1;
        buttons.interactable = true;
        buttons.blocksRaycasts = true;
        switch(PlayerDataControl.instance.playerData.nowOpenLevel)
        {
            case OpenLevel.One:
                port2.gameObject.SetActive(false);
                port3.gameObject.SetActive(false);
                break;
            case OpenLevel.Two:
                port2.gameObject.SetActive(true);
                port3.gameObject.SetActive(false);
                break;
            case OpenLevel.Three:
                port2.gameObject.SetActive(true);
                port3.gameObject.SetActive(true);
                break;
        }
    }

    public void ShowTargetPort(StageDataObj stageData)
    {
        SelectedStage = stageData;
        InfoUI.alpha = 1;
        InfoUI.interactable = true;
        InfoUI.blocksRaycasts = true;
        portImage.sprite = stageData.PortImg;
        portName.text = stageData.PortName ;
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
            StageControl.instance.SetCurrentLevel(SelectedStage);
            //Load Scene

        }
        else
            Debug.Log("no Stage select");
    }
}
